using System;
using System.Collections.Generic;
using TalaTimeTable.Api.Data.Entities;
using TalaTimeTable.Api.Services;

namespace TalaTimeTable.Api.Test.Services
{
  public class TalaFolderRepositoryTest
  {
    private ITalaRepository<TalaFolder> _sut;

    public TalaFolderRepositoryTest()
    {
      _sut = GetInMemoryFolderRepository();
      AddTestData();
    }

    private ITalaRepository<TalaFolder> GetInMemoryFolderRepository()
    {
      var dbContext = TestHelper.CreateDbContext();
      return new TalaFolderRepository(dbContext);
    }

    private void AddTestData()
    {
      var dummyTestCase = new TalaCustomer
      {
        Id = Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0d"),
        BusinessName = "BusinessName",
        Address = "Address",
        Email = "Email",
        PhoneNumber = "PhoneNumber",
        Folders = new List<TalaFolder> 
        {
          new TalaFolder
          {
            CustomerId = Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0d"),
            Id = Guid.Parse("200b9325-8c2b-468d-a1cc-9b6020192e0d"),
            Code = "FolderCode",
            Description = "FolderDescription"
          },
          new TalaFolder
          {
            CustomerId = Guid.Parse("199b9325-8c2b-468d-a1cc-9b6020192e0d"),
            Id = Guid.Parse("201b9325-8c2b-468d-a1cc-9b6020192e0d"),
            Code = "FolderCode2",
            Description = "FolderDescription2"
          }
        }
      };

    }
  }
}