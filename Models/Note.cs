using System;
using System.Collections.Generic;

namespace DiaryNotes20.Models
{
  public class Note : IPaper
  {
    public int Id { get; set; } = new Random().Next();
    public string Title { get; set; }
    public string Body { get; set; }
    public string Colour { get; set; } = "#007";
  }
}