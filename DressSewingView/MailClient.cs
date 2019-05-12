using DressSewingServiceDAL.BindingModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DressSewingView
{
    public class MailClient
    {
        private static TcpClient mailClient;

        private static SslStream stream;

        private static StreamReader reader;

        private static StreamWriter writer;

        public static void Connect()
        {
            string response = null;
            mailClient = new TcpClient();
            mailClient.Connect("pop.gmail.com", 995);
            stream = new SslStream(mailClient.GetStream());
            stream.AuthenticateAsClient("pop.gmail.com");
            reader = new StreamReader(stream, Encoding.ASCII);
            writer = new StreamWriter(stream);
            response = reader.ReadLine();
            response = SendRequest(reader, writer,
            string.Format("USER {0}", ConfigurationManager.AppSettings["MailLogin"]),
            "Ошибка авторизации, неверный логин");
            response = SendRequest(reader, writer,
            string.Format("PASS {0}",
            ConfigurationManager.AppSettings["MailPassword"]),
            "Ошибка авторизации, неверный пароль");
            CheckMail();
        }

        private static void CheckMail()
        {
            string response = null;
            try
            {
                response = SendRequest(reader, writer, string.Format("stat"), "Ошибка. Неизвестная команда (stat)");
                string[] numbers = Regex.Split(response, @"\D+");
                int number = Convert.ToInt32(numbers[1]);
                if (number > 0)
                {
                    GetMessages(number);
                }
                response = SendRequest(reader, writer, string.Format("Quit"), "Ошибка. Неизвестная команда (Quit)");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Отправка запроса и полчение ответа от почтового сервера
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        /// <param name="message"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private static string SendRequest(StreamReader reader, StreamWriter writer, 
            string message, string errorMessage)
        {
            writer.WriteLine(message);
            writer.Flush();
            var response = reader.ReadLine();
            if (response.StartsWith("-ERR"))
            {
                throw new Exception(errorMessage);
            }
            return response;
        }

        /// <summary>
        /// Получение писем
        /// </summary>
        /// <param name="number"></param>
        private static void GetMessages(int number)
        {
            string response = SendRequest(reader, writer, string.Format("RETR {0}", number), "Ошибка. Не удалось получить письмо");
            string messageId = string.Empty;
            string from = string.Empty;
            string orderSubjectMessage = string.Empty;
            string orderBodyMessage = string.Empty;
            string date = string.Empty;
            string coding = string.Empty;
            while (true)
            {
                response = reader.ReadLine();
                if (response == ".")
                    break;
                if (response.Length > 4)
                {
                    if (response.StartsWith("From:"))
                    {
                        from = response.Substring(6);
                    }
                    if (response.StartsWith("Date:"))
                    {
                        date = response.Substring(6);
                    }
                    if (response.StartsWith("Message-ID: "))
                    {
                        messageId = response.Substring(12);
                    }
                    if (response.StartsWith("Subject:"))
                    {
                        orderSubjectMessage = GetSubject(ref response, ref coding);
                        orderBodyMessage = GetBody(response, coding);
                    }
                    if (!string.IsNullOrEmpty(messageId) && 
                        !string.IsNullOrEmpty(from) && 
                        !string.IsNullOrEmpty(orderSubjectMessage) && 
                        !string.IsNullOrEmpty(date))
                    {
                        APIClient.PostRequest<MessageInfoBindingModel, bool>("api/MessageInfo/AddElement", 
                            new MessageInfoBindingModel
                            {
                                MessageId = messageId,
                                FromMailAddress = from,
                                DateDelivery = Convert.ToDateTime(date),
                                Subject = orderSubjectMessage,
                                Body = orderBodyMessage
                            });
                        messageId = string.Empty;
                        from = string.Empty;
                        date = string.Empty;
                        orderSubjectMessage = string.Empty;
                        orderBodyMessage = string.Empty;
                    }
                }
            }
        }

        /// <summary>
        /// Получение заголовка сообщения
        /// </summary>
        /// <param name="response"></param>
        /// <param name="coding"></param>
        /// <returns></returns>
        private static string GetSubject(ref string response, ref string coding)
        {
            StringBuilder subject = new StringBuilder(response);
            while (!response.StartsWith("To:"))
            {
                response = reader.ReadLine();
                subject.Append(response);
            }
            MatchCollection rr = Regex.Matches(subject.ToString(), @"(?:=\?)([^\?]+)(?:\?B\?)([^\?]*)(?:\?=)");
            if (rr.Count > 0)
            {
                coding = rr[0].Groups[1].Value;
                string message = rr[0].Groups[2].Value;
                byte[] b = Convert.FromBase64String(message);
                return Encoding.GetEncoding(coding).GetString(b);
            }
            else
            {
                return subject.ToString();
            }
        }

        /// <summary>
        /// Получение текста сообщения
        /// </summary>
        /// <param name="response"></param>
        /// <param name="coding"></param>
        /// <returns></returns>
        private static string GetBody(string response, string coding)
        {
            // идем до текста сообщения
            while (!response.StartsWith("Content-Type: text/plain") && response != ".")
            {
                response = reader.ReadLine();
            }
            // считываем следующую строку (там может быть указана кодировка)
            response = reader.ReadLine();
            StringBuilder bodyMessage = new StringBuilder();
            bool needEncoding = false;
            if (response.StartsWith("Content-Transfer-Encoding:"))
            {
                needEncoding = true;
                response = reader.ReadLine();
            }
            while (!response.StartsWith("--"))
            {
                bodyMessage.Append(response);
                response = reader.ReadLine();
            }
            if (needEncoding)
            {
                byte[] b = Convert.FromBase64String(bodyMessage.ToString());
                return Encoding.GetEncoding(coding).GetString(b);
            }
            else
            {
                return bodyMessage.ToString();
            }
        }

    }
}
