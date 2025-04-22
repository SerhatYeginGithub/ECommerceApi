using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YoutubeApi.Application.Exceptions
{
    public class ExceptionModel : ErrorStatusCode
    {
        public List<string> Errors { get; internal set; }
        IEnumerable<string> errors { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


    public class ErrorStatusCode
    {
        public int StatusCode { get; set; }
    }
}
