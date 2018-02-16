using System;
using System.ComponentModel.DataAnnotations;

namespace TalaTimeTable.Api.Models.FolderDtos
{
  public abstract class FolderForManipulationDto
  {
    [Required]
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public Guid CustomerId { get; set; }
  }
}