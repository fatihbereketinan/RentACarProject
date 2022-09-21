using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using System.Security.Cryptography;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Entities.Concrete.Car() {BrandId = 11, ColorId = 5, Model = "TeslaS2", ModelYear = 2020, DailyPrice = 1000, Description = "Electric car" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
