using System.Collections.Generic;

namespace DiaryNotes20.Models 
{
  public class Folder
  {
    public Folder()
    {
      Items = new List<IPaper>();
      RenderItems();
    }

    public List<IPaper> Items { get; set; }

    void RenderItems()
    {
      Note note1 = new Note 
      { 
        Title = "Todo", 
        Body = "Go to gym, draft application for grad schemes, meet with Manos",
        Colour = "#b00"
      };
      Book book = new Book { Title = "General" };
      Note note2 = new Note 
      {
        Title = "Communication",
        Body = "Ring mother, ask for appointment with consultant"
      };
      Note note3 = new Note
      {
        Title = "Fire",
        Body = "Get haircut, shave again to be sure, REMEMBER AFTERSHAVE"
      };
      Items.Add(note1);
      book.Pages.Add(note2);
      book.Pages.Add(note3);
      Items.Add(book);
    }
  }
}