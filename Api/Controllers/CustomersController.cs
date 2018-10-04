using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.BL.Common.Application.Dto;
using Logic.BL.Common.Application;
using Logic.BL.Entities;
using Logic.BL.Repositories;
using Logic.BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Logic.BL.Customers.Domain.Repository;
using Api.Customers.Application.Assembler;
using Api.Customers.Application.Dto;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerCreateAssembler _customerCreateAssembler;
        
        public CustomersController(
            IUnitOfWork unitOfWork,
            ICustomerRepository customerRepository,
            CustomerCreateAssembler customerCreateAssembler
            )
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _customerCreateAssembler = customerCreateAssembler;
        }


        [HttpPost]
        public IActionResult Create(/*long customerId,*/ [FromBody] CustomerCreateDto customerCreateDto)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();                
                Customer customer = _customerCreateAssembler.toEntity(customerCreateDto);
                _customerRepository.Create(customer);
                _unitOfWork.Commit(uowStatus);

                return StatusCode(StatusCodes.Status201Created, new ApiStringResponseDto("Created!"));//Ok();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback(uowStatus);
                //return StatusCode(500, new { error = e.Message });
                Console.WriteLine(e.StackTrace);
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiStringResponseDto("Internal Server Error"));
            }
        }

        
    }
}
