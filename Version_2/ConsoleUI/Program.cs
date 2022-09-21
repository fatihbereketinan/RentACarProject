using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DtoCar();
            //DeleteCar();
            //UpdateCar();
            //AddCar();

        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car() { ColorId = 5, BrandId = 2, Model = "AudiA8", DailyPrice = 1000, ModelYear = 2022, Description = "Premium" });
        }

        private static void UpdateCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car() { Id = 1, ColorId = 1, BrandId = 1, Model = "Corolla", DailyPrice = 500, ModelYear = 2022, Description = "Premium" });
        }

        private static void DeleteCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car() { Id = 1002 });
        }

        private static void DtoCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + " / " + car.CarName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }
    }
}
