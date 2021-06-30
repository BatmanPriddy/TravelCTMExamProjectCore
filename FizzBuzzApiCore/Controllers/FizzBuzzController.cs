using FizzBuzzApiCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FizzBuzzApiCore.Controllers
{
	[ApiController]
    [Route("api/v1/[controller]")]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzService _fizzBuzzService;

        /// <summary>
        /// Constructor to initialize service locally and make it accessible to the entire controller
        /// </summary>
        /// <param name="fizzBuzzService">FizzBuzzService implementation</param>
        public FizzBuzzController(IFizzBuzzService fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
        }

        /// <summary>
        /// Runs the code to get you back your "fizzbuzz" result based on inputted n value
        /// </summary>
        /// <param name="n">Input of between 1 and 100</param>
        /// <returns>200 (Ok) if successfully, 400 (BadRequest) if any issues</returns>
        [Route("{n}")]
        [HttpGet]
        public IActionResult GetFizzBuzzResult(int n)
        {
            try
            {
                // this could be done via a validation later (service) depending on complexity of the validation :)
                // simple enough to leave here for this app
                if (n > 0 && n < 101)
                {
                    // Call service to process the n value, and get back your fizzbuzz list
                    var result = _fizzBuzzService.GetFizzBuzzResult(n);

                    if (result.Success)
                    {
                        return Ok(result.Data);
                    }
                    else
                    {
                        // something failed in the service, let calling application / user know
                        return BadRequest(result.ErrorMessage);
                    }
                }
                else
                {
                    // Let the calling application / user know that the value was not within the expected range
                    return BadRequest($"Value was not specified or was not between 1 and 100, value was {n}");
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add(nameof(n), n);

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}