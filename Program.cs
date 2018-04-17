using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using Dapper;
using HtmlAgilityPack;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkQueue linkQueue = new LinkQueue("https://book.douban.com/subject/11577300/");
            Crawler crawler = new Crawler(linkQueue, 18);
            crawler.Crawling();
            InfoCrawler infoCrawler = new InfoCrawler(linkQueue);
            var infos = infoCrawler.CrawlInfo();
            foreach (var info in infos)
            {
                Console.WriteLine(info);
            }
            using(var db = new MySqlConnection("Server=192.168.99.100;Database=BookInfos;User=docker-mysql; Password=dockermysql@1994;Charset=utf8;"))
            {
                db.Open();
                db.Execute("INSERT INTO BookInfo (ISBN, Title, Author, Publisher, Image, Summary, Price) Values (@ISBN, @Title, @Author, @Publisher, @Image, @Summary, @Price);", infos);
                
            }
        }
    }
}
