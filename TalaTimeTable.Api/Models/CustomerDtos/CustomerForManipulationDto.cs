using System.ComponentModel.DataAnnotations;

namespace TalaTimeTable.Api.Models.CustomerDtos
{
  public abstract class CustomerForManipulationDto
  {
    [Required]
    public string BusinessName { get; set; }
    [Required]
    public string Address { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string PhoneNumber { get; set; }
  }
}