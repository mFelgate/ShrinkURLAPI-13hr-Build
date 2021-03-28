using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLDirectoryRepo
{
    public class URLRepo
    {
        

        // Return a full url for a given short url
        public Url getUrl(string shortUrl)
        {
            var tinyurl = new Url();
            using (DbContext ctx = new TinyURLEntities())
            {
                var tinyurls = ctx.Set<Url>();
                tinyurl = tinyurls.Where(x => shortUrl == x.shortUrl).FirstOrDefault();
            }
            return tinyurl;
        }
        // see if the url is already added, and if so return that object
        // other wise create a new database object for that url
        public Url addUrl(string fullUrl)
        {
            var tinyurl = new Url();

            using (DbContext ctx = new TinyURLEntities())
            {
                var tinyurls = ctx.Set<Url>();
                var found = tinyurls.Any(x => fullUrl == x.longUrl);
                if (!found)
                {
                    tinyurl.longUrl = fullUrl;
                    tinyurls.Add(tinyurl);
                    ctx.SaveChanges();
                }
                tinyurl.id = tinyurls.Where(x => x.longUrl == fullUrl).FirstOrDefault().id;
            }
            return tinyurl;
        }
        //add a short url to a entity just added to the databse
        public Url addShortUrl(int id, string shortUrl)
        {
            var tinyurl = new Url();
            using (DbContext ctx = new TinyURLEntities())
            {
                var tinyurls = ctx.Set<Url>();
                tinyurl = tinyurls.Find(id);
                tinyurl.shortUrl = shortUrl;
                ctx.SaveChanges();
               
            }
            return tinyurl;
        }

    }





}
