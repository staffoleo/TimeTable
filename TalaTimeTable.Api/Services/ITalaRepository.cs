using System;
using System.Collections.Generic;

namespace TalaTimeTable.Api.Services
{
  public interface ITalaRepository<T>
  {
    IEnumerable<T> GetAll(string search);
    IEnumerable<T> GetAll(IEnumerable<Guid> ids);
    T Get(Guid id);
    void Add(T item);
    void Delete(T item);
    void Update(T item);
    bool ItemExists(Guid id);

    bool Save();
  }
}