using System;
using System.Linq;
using System.Collections.Generic;
using TalaTimeTable.Api.Data;
using TalaTimeTable.Api.Data.Entities;

namespace TalaTimeTable.Api.Services
{
  public class TalaFolderRepository : ITalaRepository<TalaFolder>
  {
    private readonly ApplicationDbContext _context;

    public TalaFolderRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<TalaFolder> GetAll(string search)
    {
      if (!string.IsNullOrEmpty(search))
      {
        return _context.Folders.Where(x => x.Description.Contains(search) || 
                                           x.TalaCustomer.BusinessName.Contains(search))
                               .OrderBy(a => a.Description);
      }

      return _context.Folders.OrderBy(a => a.Description);
    }

    public IEnumerable<TalaFolder> GetAll(IEnumerable<Guid> ids)
    {
      return _context.Folders.Where(a => ids.Contains(a.Id))
                             .OrderBy(a => a.Description)
                             .ToList();
    }

    public TalaFolder Get(Guid id)
    {
      return _context.Folders.FirstOrDefault(a => a.Id == id);
    }

    public void Add(TalaFolder talaFolder)
    {
      talaFolder.Id = Guid.NewGuid();
      _context.Folders.Add(talaFolder);
    }

    public void Delete(TalaFolder talaFolder)
    {
      _context.Folders.Remove(talaFolder);
    }

    public void Update(TalaFolder talaFolder)
    {
      
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