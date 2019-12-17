using System;
using System.ComponentModel.DataAnnotations;

namespace TinyURL
{
    public class TinyUrl
    {
        public string tinyUrl { get; set; }
    }
    public class FullUrl
    {
        public string fullUrl { get; set; }
    }
    public class UrlModel
    {
        [DataType(DataType.Text)]
        public string tinyUrl { get; set; }
        [DataType(DataType.Text)]
        public string fullUrl { get; set; }
    }
}
