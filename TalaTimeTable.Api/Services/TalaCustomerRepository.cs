using System;
using System.Collections.Generic;
using System.Linq;
using TalaTimeTable.Api.Data;
using TalaTimeTable.Api.Data.Entities;

namespace TalaTimeTable.Api.Services
{
  public class TalaCustomerRepository : ITalaRepository<TalaCustomer>
  {
    private readonly ApplicationDbContext _context;

    public TalaCustomerRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<TalaCustomer> GetAll(string search)
    {
      if (!string.IsNullOrEmpty(search))
      {
        return _context.Customers.Where(x => x.BusinessName.Contains(search)).OrderBy(a => a.BusinessName);
      }

      return _context.Customers.OrderBy(a => a.BusinessName);
    }

    public IEnumerable<TalaCustomer> GetAll(IEnumerable<Guid> ids)
    {
      return _context.Customers.Where(a => ids.Contains(a.Id))
        .OrderBy(a => a.BusinessName)
        .ToList();
    }

    public TalaCustomer Get(Guid id)
    {
      return _context.Customers.FirstOrDefault(a => a.Id == id);
    }

    public void Add(TalaCustomer customer)
    {
      if(customer.Id == Guid.Empty)
        customer.Id = Guid.NewGuid();

      _context.Customers.Add(customer);
    }

    public void Delete(TalaCustomer customer)
    {
      _context.Customers.Remove(customer);
    }

    public void Update(TalaCustomer customer)
    {
      // no code in this implementation
    }

    public bool ItemExists(Guid id)
    {
      return _context.Customers.Any(c => c.Id == id);
    }

    public bool Save()
    {
      return _context.SaveChanges() >= 0;
    }
  }
}