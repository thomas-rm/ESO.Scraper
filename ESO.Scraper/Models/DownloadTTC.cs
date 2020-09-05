using ExtensionMethods;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Web;

namespace ESO.Scraper.Models
{
    public class DownloadTTC : BaseClass
    {
        const string URL = "https://eu.tamrieltradecentre.com/pc/Trade/SearchResult?";

        public DownloadTTC() : base()
        { }

        public DownloadTTC(Item _item) : base()
        {
            Item = _item;
        }

        private Item item;

        public Item Item
        {
            get { return item; }
            set { item = value; NotifyPropertyChanged(); }
        }

        public string URL_SearchByID
        {
            get { return URL + "ItemID=" + Item.ID + "&SortBy=LastSeen&Order=desc"; } //"&page="
        }

        public  void Start(int _pageCount = 1)
        {
            using (WebClient client = new WebClient())
            {
                string content = "";
                for (int i = 1; i < _pageCount+1; i++)
                {
                    content =  client.DownloadString(URL_SearchByID + "&page=" + i);
                    //content = await client.DownloadStringTaskAsync(URL_SearchByID + "&page=" + i);
                }
                byte[] byteArray = Encoding.ASCII.GetBytes(content);
                MemoryStream stream = new MemoryStream(byteArray);
                parseHTML(stream);
            }
        }

        private void parseHTML(Stream stream)
        {
            var htmldoc = new HtmlAgilityPack.HtmlDocument();
            htmldoc.Load(stream);
            var articles = htmldoc.DocumentNode.SelectNodes("//*[@class = 'cursor-pointer']");

            foreach (var article in articles)
            {
                var tblPrice = HttpUtility.HtmlDecode(article.SelectSingleNode(".//td[@class = 'gold-amount bold']").InnerText);
                tblPrice = tblPrice.WithoutWhitespace();
                HtmlNodeCollection tblPlace = article.SelectNodes(".//td[@class = 'hidden-xs']");
                string sentence = "Xx=";
                char[] separtors = sentence.ToCharArray();

                string[] positions = tblPrice.Split(separtors);
                Debug.WriteLine("----New Item----");
                foreach (string pos in positions)
                {
                    Debug.WriteLine(pos);
                }
                var place = tblPlace[1].InnerText;
                Debug.WriteLine(HttpUtility.HtmlDecode(place).WithoutWhitespace());
            }
        
        }
    }
}
