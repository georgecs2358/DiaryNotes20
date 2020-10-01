using System;
using System.Collections.Generic;

namespace DiaryNotes20.Models
{
  public class Note : IPaper
  {
    public string Title { get; set; }
    public string Body { get; set; }
    public string Colour { get; set; } = "#444";
    public int Id { get; set; } = new Random().Next();
    public bool IsFav { get; set; } = false;
    public List<IPaper> Pages { get; set; } = null;
  }
}