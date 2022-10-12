using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Diagnostics;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarRental();
            //AddCustomer();
            //AddUser();
            //DtoCar();
            //DeleteCar();
            //UpdateCar();
            //AddCar();
        }

        private static void CarRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.RentACar(new Rental() { CustomerId = 3, CarId = 2, RentDate = new DateTime(2022, 09, 06), ReturnDate = new DateTime(2022, 09, 06) });
            Console.WriteLine(result.Message);
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer() { UserId = 3, CompanyName = "Miltron Savunma" });
        }

        private static void AddUser()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User() { FirstName = "Fatih", LastName = "İnan", Email = "fatihbereketinan@gmail.com", Password = "12345" });
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Add(new Car() { ColorId = 5, BrandId = 2, Model = "Au", DailyPrice = 1000, ModelYear = 2022, Description = "Premium" });


            Console.WriteLine(result.Message);
        }

        private static void UpdateCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car() { Id = 1, ColorId = 1, BrandId = 1, Model = "Corolla", DailyPrice = 500, ModelYear = 2022, Description = "Premium" });
        }

        private static void DeleteCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.Delete(new Car() { Id = 4004});
            Console.WriteLine(result.Message);
        }

        private static void DtoCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(car.BrandName + " / " + car.CarName + " / " + car.ColorName + " / " + car.DailyPrice);
            }
        }




    }
}
