using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllRentalCars()
        {
            var result = _rentalService.AllRentalCars();
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result); 
        }
        [HttpGet("rentedcars")] 
        public IActionResult RentedCars()
        {
            var result = _rentalService.RentedCars();
            if (result.Success)
            {
                return Ok(result); 
            }
            return BadRequest(result); 
        }
        [HttpGet("notrentedcars")]
        public IActionResult NotRentedCars()
        {
            var result = _rentalService.NotRentedCars();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetails")]
        public IActionResult GetDetails()
        {
            var result = _rentalService.GetRentalCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetRentalCarById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("rent")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.RentACar(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.RentalUpdate(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.RentalDelete(rental);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
