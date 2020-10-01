using System;
using System.Collections.Generic;

namespace DiaryNotes20.Models
{
  public class Book : IPaper
  {
    public Book()
    {
      Pages = new List<IPaper>();
    }

    public string Title { get; set; }
    public string Body { get; set; } = string.Empty;
    public string Colour { get; set; } = "#654321";
    public int Id { get; set; } = new Random().Next();
    public bool IsFav { get; set; } = false;
    public List<IPaper> Pages { get; set; }
  }
}