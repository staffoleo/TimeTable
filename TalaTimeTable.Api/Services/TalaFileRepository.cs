using System;
using System.Collections.Generic;
using System.Linq;
using TalaTimeTable.Api.Data;
using TalaTimeTable.Api.Data.Entities;

namespace TalaTimeTable.Api.Services
{
  public class TalaFileRepository : ITalaRepository<TalaFile>
  {
    private readonly ApplicationDbContext _context;

    public TalaFileRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<TalaFile> GetAll(string search)
    {
      if (!string.IsNullOrEmpty(search))
      {
        return _context.Files.Where(x => x.Description.Contains(search)).OrderBy(a => a.Description);
      }

      return _context.Files.OrderBy(a => a.Description);
    }

    public IEnumerable<TalaFile> GetAll(IEnumerable<Guid> ids)
    {
      return _context.Files.Where(a => ids.Contains(a.Id))
                .OrderBy(a => a.Description)
                .ToList();
    }

    public TalaFile Get(Guid id)
    {
      return _context.Files.FirstOrDefault(a => a.Id == id);
    }

    public void Add(TalaFile file)
    {
      file.Id = Guid.NewGuid();
      _context.Files.Add(file);
    }

    public void Delete(TalaFile file)
    {
      _context.Files.Remove(file);
    }

    public void Update(TalaFile item)
    {
      throw new NotImplementedException();
    }

    public bool ItemExists(Guid id)
    {
      return _context.Folders.Any(c => c.Id == id);
    }

    public bool Save()
    {
      return _context.SaveChanges() >= 0;
    }
  }
}