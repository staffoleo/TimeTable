using System;
using System.ComponentModel.DataAnnotations;

namespace TalaTimeTable.Api.Data.Entities
{
  public class TalaFile
  {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }

    public Guid FolderId { get; set; }
    public TalaFolder TalaFolder { get; set; }
  }
}