using System;
using System.Collections.Generic;
using System.Linq;
using TalaTimeTable.Api.Data;
using TalaTimeTable.Api.Data.Entities;

namespace TalaTimeTable.Api.Services
{
  public class TalaTimeTableRepository : ITalaTimeTableRepository
  {
    private readonly ApplicationDbContext _context;

    public TalaTimeTableRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<TalaCustomer> GetCustomers(string search)
    {
      if (!string.IsNullOrEmpty(search))
      {
        return _context.Customers.Where(x => x.BusinessName.Contains(search)).OrderBy(a => a.BusinessName);
      }
      
      return _context.Customers.OrderBy(a => a.BusinessName);
    }

    public TalaCustomer GetCustomer(Guid customerId)
    {
      return _context.Customers.FirstOrDefault(a => a.Id == customerId);
    }

    public IEnumerable<TalaCustomer> GetCustomers(IEnumerable<Guid> customerIds)
    {
      return _context.Customers.Where(a => customerIds.Contains(a.Id))
                .OrderBy(a => a.BusinessName)
                .ToList();
    }

    public void AddCustomer(TalaCustomer talaCustomer)
    {
      talaCustomer.Id = Guid.NewGuid();
      _context.Customers.Add(talaCustomer);
    }

    public void DeleteCustomer(TalaCustomer talaCustomer)
    {
      _context.Customers.Remove(talaCustomer);
    }

    public void UpdateCustomer(TalaCustomer talaCustomer)
    {
      // no code in this implementation
    }

    public bool CustomerExists(Guid customerId)
    {
      return _context.Customers.Any(c => c.Id == customerId);
    }

    public bool Save()
    {
      return (_context.SaveChanges() >= 0);
    }

  }
}