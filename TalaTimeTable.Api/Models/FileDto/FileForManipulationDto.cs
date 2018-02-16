using System;
using System.ComponentModel.DataAnnotations;

namespace TalaTimeTable.Api.Models.FileDto
{
  public class FileForManipulationDto
  {
    [Required]
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public Guid FolderId { get; set; }
  }
}