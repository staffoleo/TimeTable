using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TalaTimeTable.Api.Data.Entities;
using TalaTimeTable.Api.Models.FileDto;
using TalaTimeTable.Api.Models.FolderDtos;
using TalaTimeTable.Api.Services;

namespace TalaTimeTable.Api.Controllers
{
  [Route("api/folders/{folderId}/files")]
  public class TalaFilesController : Controller
  {
    private readonly ITalaRepository<TalaFile> _talaFileRepository;

    public TalaFilesController(ITalaRepository<TalaFile> talaFileRepository)
    {
      _talaFileRepository = talaFileRepository;
    }

    [HttpGet]
    public IActionResult GetFolders([FromQuery] string search = "")
    {
      var foldersFromRepo = _talaFileRepository.GetAll(search);
      var folders = Mapper.Map<IEnumerable<FileDto>>(foldersFromRepo);

      return Ok(folders);
    }
  }
}