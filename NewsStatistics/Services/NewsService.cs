using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace NewsStatistics.Services
{
    public class NewsService
    {
        public string getNews()
        {
            string jsonData = string.Empty;
            var newsApiClient = new NewsApiClient("1016900e42d14800a27902842a18b0c8");
            var topNews = newsApiClient.GetTopHeadlines(new TopHeadlinesRequest {
                Category = Categories.Business,
                Country = Countries.TW,
                Q = "半導體"
            });

            if (topNews.Status == Statuses.Ok)
            {
                Console.WriteLine(topNews.TotalResults);
                jsonData = JsonConvert.SerializeObject(topNews.Articles);
            }
            return jsonData;

            //var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
            //{
            //    Q = "Apple",
            //    SortBy = SortBys.Popularity,
            //    Language = Languages.EN,
            //    From = new DateTime(2018, 1, 25)
            //});
            //if (articlesResponse.Status == Statuses.Ok)
            //{
            //    // total results found
            //    Console.WriteLine(articlesResponse.TotalResults);
            //    // here's the first 20
            //    foreach (var article in articlesResponse.Articles)
            //    {
            //        // title
            //        Console.WriteLine(article.Title);
            //        // author
            //        Console.WriteLine(article.Author);
            //        // description
            //        Console.WriteLine(article.Description);
            //        // url
            //        Console.WriteLine(article.Url);
            //        // published at
            //        Console.WriteLine(article.PublishedAt);
            //    }
            //}
            //Console.ReadLine();
        }
    }
}
