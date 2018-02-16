using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TalaTimeTable.Api.Data.Entities;
using TalaTimeTable.Api.Models.CustomerDtos;
using TalaTimeTable.Api.Services;

namespace TalaTimeTable.Api.Controllers
{
  [Route("api/customers")]
  public class CustomersController : Controller
  {
    private readonly ITalaRepository<TalaCustomer> _talaCustomerRepository;

    public CustomersController(ITalaRepository<TalaCustomer> talaRepo)
    {
      _talaCustomerRepository = talaRepo;
    }

    [HttpGet]
    public IActionResult GetCustomers([FromQuery] string search = "")
    {
      var customersFromRepo = _talaCustomerRepository.GetAll(search);
      var customers = Mapper.Map<IEnumerable<CustomerDto>>(customersFromRepo);
      
      return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetCustomer(Guid id)
    {
      var customerFromRepo = _talaCustomerRepository.Get(id);

      if (customerFromRepo == null)
      {
        return NotFound();
      }

      var customer = Mapper.Map<CustomerDto>(customerFromRepo);
      return Ok(customer);
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] CustomerForCreationDto customer)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var customerEntity = Mapper.Map<TalaCustomer>(customer);
      _talaCustomerRepository.Add(customerEntity);
      if (!_talaCustomerRepository.Save())
      {
        throw new Exception("Creating a talaCustomer failed on save");
      }

      return NoContent();
    }

    [HttpPut]
    public IActionResult UpdateCustomer(Guid id, [FromBody] CustomerForUpdateDto customer)
    {
      if (!ModelState.IsValid)
        return BadRequest();

      if (_talaCustomerRepository.ItemExists(id))
        return NotFound();

      var customerFromRepo = _talaCustomerRepository.Get(id);
      Mapper.Map(customer, customerFromRepo);

      _talaCustomerRepository.Update(customerFromRepo);

      if(_talaCustomerRepository.Save())
        throw new Exception($"Updating ustomer {id} failed on save.");

      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(Guid id)
    {
      var customerFromRepo = _talaCustomerRepository.Get(id);
      if (customerFromRepo == null)
      {
        return NotFound();
      }

      _talaCustomerRepository.Delete(customerFromRepo);

      if (!_talaCustomerRepository.Save())
      {
        throw new Exception($"Deleting customer {id} failed on save");
      }

      return NoContent();
    }
  }
}
