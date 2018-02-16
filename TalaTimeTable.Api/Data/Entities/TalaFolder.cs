using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalaTimeTable.Api.Data.Entities
{
  public class TalaFolder
  {
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string Code { get; set; }
    [Required]
    public string Description { get; set; }

    public Guid CustomerId { get; set; }
    public TalaCustomer TalaCustomer { get; set; }

    public List<TalaFile> Files { get; set; }
  }
}