using System.Collections.Generic;

namespace DiaryNotes20.Models 
{
  public class Folder
  {
    public Folder()
    {
      Notes = new List<Note>();
      Note placeholder = new Note{ Title = "Untitled note", Body = "Undefined"};
      Notes.Add(placeholder);
      Books = new List<Book>();
    }

    public List<Note> Notes { get; set; }
    public List<Book> Books { get; set; }
  }
}