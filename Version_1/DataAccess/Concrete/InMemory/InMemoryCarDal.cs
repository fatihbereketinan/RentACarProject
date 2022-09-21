using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>() {
                new Car() { Id=1,BrandId=1,ColorId=123, ModelYear=1995, DailyPrice=10000, Description="Sedan"},
                new Car() { Id=2,BrandId=2,ColorId=155, ModelYear=2000, DailyPrice=15000, Description="CUV"},
                new Car() { Id=3,BrandId=2,ColorId=11, ModelYear=2012, DailyPrice=20000, Description="HP"},
                new Car() { Id=4,BrandId=3,ColorId=188, ModelYear=2008, DailyPrice=12000, Description="Sedan"},
                new Car() { Id=5,BrandId=1,ColorId=12324, ModelYear=2020, DailyPrice=40000, Description="CUV"}};
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear; 
            carToUpdate.DailyPrice=car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
