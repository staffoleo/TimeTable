using System;
using System.Collections.Generic;
using TalaTimeTable.Api.Data.Entities;

namespace TalaTimeTable.Api.Services
{
  public interface ITalaTimeTableRepository
  {
    IEnumerable<TalaCustomer> GetCustomers(string search);
    TalaCustomer GetCustomer(Guid customerId);
    IEnumerable<TalaCustomer> GetCustomers(IEnumerable<Guid> customerIds);
    void AddCustomer(TalaCustomer talaCustomer);
    void DeleteCustomer(TalaCustomer talaCustomer);
    void UpdateCustomer(TalaCustomer talaCustomer);
    bool CustomerExists(Guid customerId);
    
    bool Save();
  }
}