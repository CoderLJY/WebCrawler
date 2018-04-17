using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace WebCrawler
{
    public class Crawler
    {
        private int _currentdepth = 1;

        private int _crawldepth;
        private LinkQueue _linkqueue;
        public int CurrentDepth
        {
            get => _currentdepth;
        }
        public Crawler(LinkQueue linkQueue, int crawlDeepth = 10)
        {
            this._linkqueue = linkQueue;
            this._crawldepth = crawlDeepth;
        }

        public void Crawling()
        {

            while (!this._linkqueue.UnVisitedEmpty)
            {
                if (this._currentdepth <= this._crawldepth)
                {
                    string visiturl = this._linkqueue.UnVisitedDequece();
                    Console.WriteLine($"Pop out one url {visiturl} from unvisited url list");
                    if (visiturl.Equals(""))
                        continue;
                    List<string> links = this.HyperLink(visiturl);
                    Console.WriteLine($"Get {links.Count} new links");
                    this._linkqueue.AddVisitedUrl(visiturl);
                    Console.WriteLine($"Visited url count : {this._linkqueue.VisitedCount}");
                    Console.WriteLine($"Visited deepth: {this._currentdepth}");
                    foreach (var link in links)
                        this._linkqueue.AddUnVisitedUrl(link);
                    Console.WriteLine($"{this._linkqueue.UnVisitedCount} links");
                    this._currentdepth++;



                }
                else
                {
                    break;
                }
            }
        }

        private List<string> HyperLink(string url)
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(s);
            // var table = doc.DocumentNode.SelectNodes("//h1/span").Descendants();
            // foreach(var node in table)
            // {
            // Console.WriteLine(node.OuterHtml);
            // }
            // var author = doc.DocumentNode.SelectNodes("//div/span/a[contains(@href, 'search')]");
            // foreach(var node in author)
            // {
            // Console.WriteLine(node.FirstChild.OuterHtml);
            // }
            // var press = doc.DocumentNode.SelectNodes("//div[contains(@id, 'info')]/span[contains(@class,'pl')]");
            // foreach(var node in press)
            // {
            // Console.WriteLine(node.NextSibling.OuterHtml);
            // }
            var httplink = doc.DocumentNode.SelectNodes("//div[contains(@id, 'db-rec-section')]/div[contains(@class, 'content clearfix')]/dl/dd/a");
            List<string> links = new List<string>();
            foreach (var node in httplink)
            {
                Console.WriteLine(node.Attributes["href"].Value);
                links.Add(node.Attributes["href"].Value);
            }
            data.Close();
            reader.Close();
            return links;

        }
    }
}