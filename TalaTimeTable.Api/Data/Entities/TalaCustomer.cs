using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalaTimeTable.Api.Data.Entities
{
  public class TalaCustomer
  {
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string BusinessName { get; set; }

    [Required]
    public string Address { get; set; }
    
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public List<TalaFolder> Folders { get; set; }
  }
}