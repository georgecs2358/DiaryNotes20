using System.Collections.Generic;

namespace DiaryNotes20.Models 
{
  public interface IPaper
  {
    string Title { get; set; }
    string Body { get; set; }
    string Colour { get; set; }
    int Id { get; set; }
    bool IsFav { get; set; }
    List<IPaper> Pages { get; set; }
  }
}