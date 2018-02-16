using System;

namespace TalaTimeTable.Api.Models.CustomerDtos
{
  public class CustomerDto
  {
    public Guid Id { get; set; }
    public string BusinessName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
  }
}