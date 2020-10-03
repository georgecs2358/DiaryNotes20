using System.Collections.Generic;

namespace DiaryNotes20.Models 
{
  public class Folder
  {
    public Folder()
    {
      Items = new List<IPaper>();
      Note placeholder = new Note{ Title = "Untitled note", Body = "Undefined"};
      Items.Add(placeholder);
    }

    public List<IPaper> Items { get; set; }
  }
}