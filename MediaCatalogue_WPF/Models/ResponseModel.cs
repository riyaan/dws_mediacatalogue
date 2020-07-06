using System.Collections.Generic;
using System.Net;

namespace MediaCatalogue_WPF.Models
{
    public class ResponseModel<T> where T:class
    {
        public ResponseModel()
        {
            Data = new List<T>();
        }

        public string Message { get; set; }

        public List<T> Data { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}