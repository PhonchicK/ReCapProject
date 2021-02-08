using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carmng = new CarManager(new EfCarDal());
            foreach(CarDetailDto item in carmng.GetCarsWithDetails())
            {
                Console.WriteLine(item.CarName + " - " + item.BrandName + " - " + item.ColorName);
            }
        }
    }
}
