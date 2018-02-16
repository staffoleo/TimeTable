using System;

namespace TalaTimeTable.Api.Models.FileDto
{
  public class FileDto
  {
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public Guid FolderId { get; set; }
  }
}