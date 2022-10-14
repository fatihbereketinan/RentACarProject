using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult RentACar(Rental rental);
        IResult RentalUpdate(Rental rental);
        IResult RentalDelete(Rental rental);
        IDataResult<List<Rental>> AllRentalCars();
        IDataResult<List<Rental>> RentedCars();
        IDataResult<List<Rental>> NotRentedCars();
        IDataResult<List<RentalDetailDto>> GetRentalCarDetails();
        IDataResult<Rental> GetRentalCarById(int rentalId);


    }
}
