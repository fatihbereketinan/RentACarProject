using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> AllRentalCars()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalCarDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalCarDetails(), Messages.CarsListed);
        }
        public IDataResult<List<Rental>> RentedCars()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate == null), Messages.CarsListed);
        }

        public IDataResult<List<Rental>> NotRentedCars()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate != null), Messages.CarsListed);
        }
        public IDataResult<Rental> GetRentalCarById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r =>r.Id==id));
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult RentACar(Rental rental)
        {
            //ValidationTool.Validate(new RentalValidator(), rental);

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult RentalDelete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IResult RentalUpdate(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

    }
}
