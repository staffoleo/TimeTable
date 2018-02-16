using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TalaTimeTable.Api.Data.Entities;
using TalaTimeTable.Api.Models.FolderDtos;
using TalaTimeTable.Api.Services;

namespace TalaTimeTable.Api.Controllers
{
  [Route("api/folders")]
  public class FoldersController : Controller
  {
    private readonly ITalaRepository<TalaFolder> _talaFolderRepository;

    public FoldersController(ITalaRepository<TalaFolder> talaFolderRepository)
    {
      _talaFolderRepository = talaFolderRepository;
    }

    [HttpGet]
    public IActionResult GetFolders([FromQuery] string search = "")
    {
      var foldersFromRepo = _talaFolderRepository.GetAll(search);
      var folders = Mapper.Map<IEnumerable<FolderDto>>(foldersFromRepo);

      return Ok(folders);
    }
  }
}