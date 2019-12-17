using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLDirectoryRepo;
using System.Web;

namespace TinyURL.service
{
    public class TinyUrlService
    {
        //instantiate the repo
        private URLRepo repo = new URLRepo();
        public UrlModel getUrl(string tinyUrl)
        {
            var urlEntity = repo.getUrl(EncodeInputs(tinyUrl));
            return urlMapper(urlEntity);
        }

        //add the url given through the controller
        public UrlModel addUrl(string fullUrl)
        {
            // addU the encoded url to the database
            var urlEntity = repo.addUrl(EncodeInputs(fullUrl));
            var shortUrl = this.makeShortUrl(urlEntity.id);
            urlEntity = repo.addShortUrl(urlEntity.id, shortUrl);
            
            return urlMapper(urlEntity);
        }
        // map the database object to the model and decode it
        private UrlModel urlMapper(url urlEntity)
        {
            return new UrlModel()
            {
                fullUrl = DecodeInputs(urlEntity.longUrl),
                tinyUrl = DecodeInputs(urlEntity.shortUrl)
            };
        }
        
        private string EncodeInputs(string input)
        {
            return HttpUtility.UrlEncode(input);

        }
        private string DecodeInputs(string input)
        {
            return HttpUtility.UrlDecode(input);
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


