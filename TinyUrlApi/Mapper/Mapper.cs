using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TinyURL;
using URLDirectoryRepo;

namespace TinyUrlApi.Mapper
{
    public class Mapper
    {
        public UrlModel urlMapper(Url urlEntity)
        {
            return new UrlModel()
            {
                fullUrl = DecodeInputs(urlEntity.longUrl),
                tinyUrl = DecodeInputs(urlEntity.shortUrl)
            };
        }

        private string DecodeInputs(string input)
        {
            return HttpUtility.UrlDecode(input);
        }
    }
}