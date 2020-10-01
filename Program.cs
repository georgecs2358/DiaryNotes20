using System;
using System.Collections.Generic;
using System.IO;
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
    private static bool IsInitialLoad { get; set; } = true;
    public static List<IPaper> AccessItems(int rootID=-1)
    {
      if (IsInitialLoad && rootID==-1)
      {
        Folder = new Folder();
        IsInitialLoad = false;
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
