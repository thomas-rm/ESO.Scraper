using ESO.Scraper.Models;
using System;
using System.Diagnostics;

namespace ESO.Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Item item = new Item(11971, "Kernholz");
            DownloadTTC dl = new DownloadTTC(item);
            dl.Start();
            Console.WriteLine("Second Line");
            Console.ReadLine();
            Main(null);
        }
    }
}
