﻿using System;

namespace TalaTimeTable.Api.Models.FolderDtos
{
  public class FolderDto
  {
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public Guid CustomerId { get; set; }
  }
}