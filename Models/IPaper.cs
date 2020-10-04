using System.Collections.Generic;

namespace DiaryNotes20.Models 
{
  public interface IPaper
  {
    int Id { get; set; }
    string Title { get; set; }
    string Body { get; set; }
    string Colour { get; set; }
  }
}