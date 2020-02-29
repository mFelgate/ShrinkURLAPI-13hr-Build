using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLDirectoryRepo;
using System.Web;
using TinyUrlApi.Mapper;

namespace TinyURL.service
{
    public class TinyUrlService
    {

        private Mapper mapper = new Mapper();
        private URLRepo repo = new URLRepo();
        public UrlModel getUrl(string tinyUrl)
        {
            var urlEntity = repo.getUrl(EncodeInputs(tinyUrl));
            return mapper.urlMapper(urlEntity);
        }

        //add the url given through the controller
        public UrlModel addUrl(string fullUrl)
        {
            // addU the encoded url to the database
            var urlEntity = repo.addUrl(EncodeInputs(fullUrl));
            var shortUrl = this.makeShortUrl(urlEntity.id);
            urlEntity = repo.addShortUrl(urlEntity.id, shortUrl);
            
            return mapper.urlMapper(urlEntity);
        }

        private string EncodeInputs(string input)
        {
            return HttpUtility.UrlEncode(input);

        }
        // use the char map to make a string
        //algorithm found at https://www.geeksforgeeks.org/how-to-design-a-tiny-url-or-url-shortener/
        private string makeShortUrl(int id)
        {
            var charMap = "abcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
            StringBuilder shorturl = new StringBuilder();
            while (id > 0)
            {
                shorturl.Append(charMap[id % 36]);
                id = id / 36;
            }

            // Reverse shortURL to complete base conversion 
            return shorturl.ToString();
        }
    }
}


