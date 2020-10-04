using System;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
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

    public static void LoadNotes()
    {
      string GetData = null;
      try
      { GetData = File.ReadAllText(@"C:\Users\Public\DiaryNotesData.json"); } 
      catch (FileNotFoundException e) 
      {
        Console.WriteLine(e.Message, "Hence a default data file was created.");
        GetData = @"{""Notes"":[{""Id"":1893539463,""Title"":""Welcome to DiaryNotes20 :)"",""Body"":""..."",""Colour"":""#007""}],""Books"":[]}";
        TextWriter textWriter = new StreamWriter(
          @"C:\Users\Public\DiaryNotesData.json"
        );
        textWriter.WriteLine(GetData);
        textWriter.Close();
      } 
      finally 
      { AppBuilder.Folder = JsonSerializer.Deserialize<Folder>(GetData); }
    }

    public static void SaveNotes()
    {
      string PostData = JsonSerializer.Serialize(AppBuilder.Folder);
      File.WriteAllText(@"C:\Users\Public\DiaryNotesData.json", PostData);
    }

  }

}
