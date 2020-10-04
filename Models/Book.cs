using System;
using System.Collections.Generic;

namespace DiaryNotes20.Models
{
  public class Book : IPaper
  {
    public Book()
    {
      Pages = new List<Note>();
    }

    public int Id { get; set; } = new Random().Next();
    public string Title { get; set; }
    public string Body { get; set; } = string.Empty;
    public string Colour { get; set; } = "#654321";
    public List<Note> Pages { get; set; }
  }
}