using System.Collections.Generic;
using DiaryNotes20.Models;

namespace DiaryNotes20
{
  public class AppBuilder
  {
    static AppBuilder()
    {
      Folder = new Folder();
    }

    public static Folder Folder { get; set; }
    public static int CurrentNoteItemId { get; set; } = -1;
    public static int CurrentBookItemId { get; set; } = -1;
    public static bool CurrentBaseTypeIsNote { get; set; } = true;

    public static List<IPaper> AccessItems()
    {
      List<IPaper> items = new List<IPaper>();
      for (int i=0; i<Folder.Notes.Count; i++)
      {
        items.Add(Folder.Notes[i]);
      }
      for (int i=0; i<Folder.Books.Count; i++)
      {
        items.Add(Folder.Books[i]);
      }
      return items;
    }

    public static Note AccessCurrentNoteItem()
    {
      return Folder.Notes.Find(note => note.Id == CurrentNoteItemId);
    }
    public static Book AccessCurrentBookItem()
    {
      return Folder.Books.Find(book => book.Id == CurrentBookItemId);
    }
    public static List<Note> AccessBookContents(int rootID)
    {
      return Folder.Books.Find(book => book.Id == rootID).Pages;
    }
  }
}

