using System;
using System.Collections.Generic;
using System.Linq;
using TalaTimeTable.Api.Data.Entities;
using TalaTimeTable.Api.Services;
using Xunit;

namespace TalaTimeTable.Api.Test.Services
{
  public class TalaCustomerRepositoryTest
  {
    private readonly ITalaRepository<TalaCustomer> _sut;

    public TalaCustomerRepositoryTest()
    {
      _sut = GetInMemoryCustomerRepository();
      AddTestData();
    }

    [Fact]
    public void ShouldGet2Customers()
    {
      var queryresult = _sut.GetAll("").ToList();

      Assert.Equal(2, queryresult.Count);
    }

    [Fact]
    public void ShouldGetCustomerByIds()
    {
      IEnumerable<Guid> ids = new List<Guid> {Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0d")};

      var queryresult = _sut.GetAll(ids).ToList();

      Assert.Single(queryresult);
      Assert.Equal("BusinessName", queryresult.FirstOrDefault()?.BusinessName);
    }

    [Fact]
    public void ShouldGetCustomerById()
    {
      var id = Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0d");

      var queryresult = _sut.Get(id);

      Assert.Equal("BusinessName", queryresult.BusinessName);
    }

    [Fact]
    public void ShouldAddCustomer()
    {
      var toAdd = new TalaCustomer
      {
        BusinessName = "xxx"
      };
      _sut.Add(toAdd);
      _sut.Save();

      var queryresult = _sut.GetAll("x").ToList();

      Assert.Single(queryresult);
    }

    [Fact]
    public void ShouldUpdateCustomer()
    {
      var id = Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0d");
      var queryresult = _sut.Get(id);

      queryresult.BusinessName = "UpdatedBusinessName";
      _sut.Save();

      var modifiedResult = _sut.Get(id);
      Assert.Equal("UpdatedBusinessName", modifiedResult.BusinessName);
    }

    [Fact]
    public void ShouldDeleteCustomer()
    {
      var id = Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0d");
      var queryresult = _sut.Get(id);
      
      _sut.Delete(queryresult);
      _sut.Save();

      var all = _sut.GetAll("").ToList();

      Assert.Single(all);
    }

    [Fact]
    public void ShouldFindAnExistingCustomer()
    {
      var id = Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0d");
      var queryresult = _sut.ItemExists(id);

      Assert.True(queryresult);
    }

    [Fact]
    public void ShouldNotFindANotExistingCustomer()
    {
      var id = Guid.Parse("200b9325-8c2b-468d-a1cc-9b6020192e0d");
      var queryresult = _sut.ItemExists(id);

      Assert.False(queryresult);
    }



    private ITalaRepository<TalaCustomer> GetInMemoryCustomerRepository()
    {
      var dbContext = TestHelper.CreateDbContext();
      return new TalaCustomerRepository(dbContext);
    }

    private void AddTestData()
    {
      var dummyCustomer1 = new TalaCustomer
      {
        Id = Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0d"),
        BusinessName = "BusinessName",
        Address = "Address",
        Email = "Email",
        PhoneNumber = "PhoneNumber"
      };
      var dummyCustomer2 = new TalaCustomer
      {
        Id = Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0e"),
        BusinessName = "BusinessName2",
        Address = "Address2",
        Email = "Email2",
        PhoneNumber = "PhoneNumber2"
      };
      _sut.Add(dummyCustomer1);
      _sut.Add(dummyCustomer2);
      _sut.Save(); 
    }
  }
}