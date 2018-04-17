using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;

namespace WebCrawler
{
    public class InfoCrawler
    {
        private LinkQueue _linkqueue;
        public InfoCrawler(LinkQueue linkQueue)
        {
            this._linkqueue = linkQueue;
        }

        public List<BookInfo> CrawlInfo()
        {
            List<BookInfo> result = new List<BookInfo>();
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                foreach (var url in this._linkqueue.UnVisited)
                {
                    using (Stream data = client.OpenRead("https://api.douban.com/v2/book/" + url.Split('/')[4]))
                    {
                        StreamReader reader = new StreamReader(data);
                        string s = reader.ReadToEnd();
                        JObject douban = JObject.Parse(s);
                        // Console.WriteLine(douban["title"]);
                        // Console.WriteLine(douban["author"][0]);
                        // Console.WriteLine(douban["publisher"]);
                        // Console.WriteLine(douban["isbn13"]);
                        // Console.WriteLine(douban["image"]);
                        // Console.WriteLine(douban["summary"]);
                        // Console.WriteLine(douban["price"]);
                        result.Add(new BookInfo
                        {
                            Title = douban["title"].ToString(),
                            Author = douban["author"][0].ToString(),
                            Publisher = douban["publisher"].ToString(),
                            ISBN = douban["isbn13"].ToString(),
                            Image = douban["image"].ToString(),
                            Summary = douban["summary"].ToString(),
                            Price = douban["price"].ToString()


                        });
                    }



                }


            }
            return result;


        }
    }
}