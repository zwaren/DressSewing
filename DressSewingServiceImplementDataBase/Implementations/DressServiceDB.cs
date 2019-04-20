using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DressSewingModel;
using DressSewingServiceDAL.BindingModels;
using DressSewingServiceDAL.Interfaces;
using DressSewingServiceDAL.ViewModels;

namespace DressSewingServiceImplementDataBase.Implementations
{
	public class DressServiceDB : IDressService
	{
		private AbstractDbContext context;

		public DressServiceDB(AbstractDbContext context)
		{
			this.context = context;
		}

		public void AddElement(DressBindingModel model)
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					Dress element = context.Dresses.FirstOrDefault(rec =>
					rec.DressName == model.DressName);
					if (element != null)
					{
						throw new Exception("Уже есть изделие с таким названием");
					}
					element = new Dress
					{
						DressName = model.DressName,
						Price = model.Price
					};
					context.Dresses.Add(element);
					context.SaveChanges();
					// убираем дубли по компонентам
					var groupMaterials = model.DressMaterials
					.GroupBy(rec => rec.MaterialId)
					.Select(rec => new
					{
						MaterialId = rec.Key,
						Count = rec.Sum(r => r.Count)
					});
					// добавляем компоненты
					foreach (var groupMaterial in groupMaterials)
					{
						context.DressMaterials.Add(new DressMaterial
						{
							DressId = element.Id,
							MaterialId = groupMaterial.MaterialId,
							Count = groupMaterial.Count
						});
						context.SaveChanges();
					}
					transaction.Commit();
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}
		}

		public void DelElement(int id)
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					Dress element = context.Dresses.FirstOrDefault(rec => rec.Id ==
					id);
					if (element != null)
					{
						// удаяем записи по компонентам при удалении изделия
						context.DressMaterials.RemoveRange(context.DressMaterials.Where(rec =>
						    rec.DressId == id));
						context.Dresses.Remove(element);
						context.SaveChanges();
					}
					else
					{
						throw new Exception("Элемент не найден");
					}
					transaction.Commit();
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}
		}

		public DressViewModel GetElement(int id)
		{
			Dress element = context.Dresses.FirstOrDefault(rec => rec.Id == id);
			if (element != null)
			{
				return new DressViewModel
				{
					Id = element.Id,
					DressName = element.DressName,
					Price = element.Price,
					DressMaterials = context.DressMaterials
							.Where(recPC => recPC.DressId == element.Id)
							.Select(recPC => new DressMaterialViewModel
							{
								Id = recPC.Id,
								DressId = recPC.DressId,
								MaterialId = recPC.MaterialId,
								MaterialName = recPC.Material.MaterialName,
								Count = recPC.Count
							})
							.ToList()
				};
			}
			throw new Exception("Элемент не найден");
		}

		public List<DressViewModel> GetList()
		{
			List<DressViewModel> result = context.Dresses.Select(rec => new DressViewModel
						{
							Id = rec.Id,
							DressName = rec.DressName,
							Price = rec.Price,
							DressMaterials = context.DressMaterials
									.Where(recPC => recPC.DressId == rec.Id)
									.Select(recPC => new DressMaterialViewModel
									{
										Id = recPC.Id,
										DressId = recPC.DressId,
										MaterialId = recPC.MaterialId,
										MaterialName = recPC.Material.MaterialName,
										Count = recPC.Count
									})
									.ToList()
						})
			.ToList();
			return result;
		}

		public void UpdElement(DressBindingModel model)
		{
			using (var transaction = context.Database.BeginTransaction())
			{
				try
				{
					Dress element = context.Dresses.FirstOrDefault(rec =>
					rec.DressName == model.DressName && rec.Id != model.Id);
					if (element != null)
					{
						throw new Exception("Уже есть изделие с таким названием");
					}
					element = context.Dresses.FirstOrDefault(rec => rec.Id == model.Id);
					if (element == null)
					{
						throw new Exception("Элемент не найден");
					}
					element.DressName = model.DressName;
					element.Price = model.Price;
					context.SaveChanges();
					// обновляем существуюущие компоненты
					var compIds = model.DressMaterials.Select(rec =>
					rec.MaterialId).Distinct();
					var updateMaterials = context.DressMaterials.Where(rec =>
					rec.DressId == model.Id && compIds.Contains(rec.MaterialId));
					foreach (var updateMaterial in updateMaterials)
					{
						updateMaterial.Count =
						model.DressMaterials.FirstOrDefault(rec => rec.Id == updateMaterial.Id).Count;
					}
					context.SaveChanges();
					context.DressMaterials.RemoveRange(context.DressMaterials.Where(rec =>
					rec.DressId == model.Id && !compIds.Contains(rec.MaterialId)));
					context.SaveChanges();
					// новые записи
					var groupMaterials = model.DressMaterials
							.Where(rec => rec.Id == 0)
							.GroupBy(rec => rec.MaterialId)
							.Select(rec => new
							{
								MaterialId = rec.Key,
								Count = rec.Sum(r => r.Count)
							});
					foreach (var groupMaterial in groupMaterials)
					{
						DressMaterial elementPC =
						context.DressMaterials.FirstOrDefault(rec => rec.DressId == model.Id &&
						rec.MaterialId == groupMaterial.MaterialId);
						if (elementPC != null)
						{
							elementPC.Count += groupMaterial.Count;
							context.SaveChanges();
						}
						else
						{
							context.DressMaterials.Add(new DressMaterial
							{
								DressId = model.Id,
								MaterialId = groupMaterial.MaterialId,
								Count = groupMaterial.Count
							});
							context.SaveChanges();
						}
					}
					transaction.Commit();
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw;
				}
			}
		}
	}
}
