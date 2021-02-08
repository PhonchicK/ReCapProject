using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public CarDetailDto GetCarDetailsById(int id)
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars
                             where p.CarId == id
                             join b in context.Brands
                             on p.BrandId equals b.BrandId
                             join cl in context.Colors
                             on p.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 CarName = p.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 ModelYear = p.ModelYear,
                                 Description = p.Description
                             };
                return result.First();
            }
        }

        public List<CarDetailDto> GetCarsWithDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from p in context.Cars
                             join b in context.Brands
                             on p.BrandId equals b.BrandId
                             join cl in context.Colors
                             on p.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 CarName = p.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 ModelYear = p.ModelYear,
                                 Description = p.Description
                             };
                return result.ToList();
            }
        }
    }
}
