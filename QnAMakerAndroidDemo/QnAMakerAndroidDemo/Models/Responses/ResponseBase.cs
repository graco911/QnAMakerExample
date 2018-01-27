using Newtonsoft.Json;
using System.Collections.Generic;

namespace QnAMakerAndroidDemo.Models.Responses
{

    public class Answer
    {
        public string answer { get; set; }
        public List<string> questions { get; set; }
        public float score { get; set; }
    }

    public abstract class ResponseBase
    {
        public List<Answer> answers { get; set; }
    }
}