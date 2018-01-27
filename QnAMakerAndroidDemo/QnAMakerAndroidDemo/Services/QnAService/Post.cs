using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QnAMakerAndroidDemo.Models.Responses;
using System.Web;
using Newtonsoft.Json;
using Android.Util;

namespace QnAMakerAndroidDemo.Services
{
    public static partial class QnAService
    {
        public static async Task<ResponseData> Post(string message)
        {
            var Response = new ResponseData();
            string responseString = string.Empty;
            var knowledgebaseId = "3bb6f03f-a51b-461a-ac36-9cb96b5043ae"; // Use knowledge base id created.
            var qnamakerSubscriptionKey = "6a814c9258e14fb2b05c7fd018890053"; //Use subscription key assigned to you.

            try
            {

                //Build the URI
                Uri qnamakerUriBase = new Uri("https://westus.api.cognitive.microsoft.com/qnamaker/v2.0");
                var builder = new UriBuilder($"{qnamakerUriBase}/knowledgebases/{knowledgebaseId}/generateAnswer");

                //Add the question as part of the body
                var postBody = $"{{\"question\": \"{message}\"}}";

                //Send the POST request
                using (WebClient client = new WebClient())
                {
                    //Set the encoding to UTF8
                    client.Encoding = System.Text.Encoding.UTF8;

                    //Add the subscription key header
                    client.Headers.Add("Ocp-Apim-Subscription-Key", qnamakerSubscriptionKey);
                    client.Headers.Add("Content-Type", "application/json");
                    responseString = client.UploadString(builder.Uri, postBody);

                    if (responseString.Length > 0)
                    {
                        JsonConvert.PopulateObject(responseString, Response);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Debug("Error: ", ex.Message);
            }

            return Response;
        }
    }
}