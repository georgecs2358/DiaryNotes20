using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DiaryNotes20.Models;
using ElectronNET.API;

namespace DiaryNotes20
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
      {
        webBuilder.UseElectron(args);
        webBuilder.UseStartup<Startup>();
      });

    public static Folder Folder { get; set; }
    public static int CurrentNoteItemId { get; set; } = -1;
    public static int CurrentBookItemId { get; set; } = -1;
    public static bool CurrentBaseTypeIsNote { get; set; } = true;

    public static void LoadNotes()
    {
      string GetData = null;
      try
      {
        GetData = File.ReadAllText(@"C:\Users\Public\DiaryNotesData.json");
      } catch (FileNotFoundException e) {
        Console.WriteLine(e.Message, "Hence a default data file was created.");
        GetData = @"{""Items"":[{""Title"":""Untitled book"",
        ""Body"":"""",""Colour"":""#654321"",""Id"":420846611,""IsFav"":false,
        ""Pages"":[{""Title"":""Untitled note"",""Body"":"""",""Colour"":
        ""#444"",""Id"":134464447,""IsFav"":false,""Pages"":null}]},{""Title"":
        ""Untitled note"",""Body"":"""",""Colour"":""#444"",""Id"":822834995,
        ""IsFav"":false,""Pages"":null}]}";
        TextWriter textWriter = new StreamWriter(
          @"C:\Users\Public\DiaryNotesData.json"
        );
        textWriter.WriteLine(GetData);
        textWriter.Close();
      } finally {
        Folder = JsonSerializer.Deserialize<Folder>(GetData);
      }
    }

    public static void SaveNotes()
    {
      string PostData = JsonSerializer.Serialize(Folder);
      File.WriteAllText(@"C:\Users\Public\DiaryNotesData.json", PostData);
    }

    public static List<IPaper> AccessItems(int rootID=-1)
    {
      if (Folder == null && rootID== -1)
      {
        Folder = new Folder();
        return Folder.Items;
      } else if (rootID == -1) {
        return Folder.Items;
      } else {
        return Folder.Items.Find(book => book.Id == rootID).Pages;
      }
    }
    public static IPaper AccessCurrentItem(bool IsNote=true)
    {
      if (IsNote)
      {
        return Folder.Items.Find(note => note.Id == CurrentNoteItemId);
      } else {
        return Folder.Items.Find(book => book.Id == CurrentBookItemId);
      }
    }

  }

}
