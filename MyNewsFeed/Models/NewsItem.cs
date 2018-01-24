using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyNewsFeed.Models
{
    public class NewsItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string url { get; set; }
        public string urlToImage { get; set; }

        public NewsItem()
        {
        }

        public static List<NewsItem> GetHeadlines(string country)
        {
            
            var client = new RestClient("https://newsapi.org/v2/");
            var request = new RestRequest("top-headlines?country="+country+"&apiKey=" + EnvironmentVariables.apiKey, Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {

                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var NewsItemList = JsonConvert.DeserializeObject<List<NewsItem>>(jsonResponse["articles"].ToString());
            return NewsItemList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
