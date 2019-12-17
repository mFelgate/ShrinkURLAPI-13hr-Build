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
        public DbContext ctx = new URLDirectoryEntities();

        // Return a full url for a given short url
        public url getUrl(string shortUrl)
        {
            var tinyurl = new url();
            using (ctx)
            {
                var tinyurls = ctx.Set<url>();
                tinyurl = tinyurls.Where(x => shortUrl == x.shortUrl).FirstOrDefault();
            }
            return tinyurl;
        }
        // see if the url is already added, and if so return that object
        // other wise create a new database object for that url
        public url addUrl(string fullUrl)
        {
            var tinyurl = new url();
            
            var tinyurls = ctx.Set<url>();
            var found = tinyurls.Any(x => fullUrl == x.longUrl);
            if (!found)
            {
                tinyurl.longUrl = fullUrl;
                tinyurls.Add(tinyurl);
                ctx.SaveChanges();
            }
            tinyurl.id = tinyurls.Where(x => x.longUrl == fullUrl).FirstOrDefault().id;
            
            return tinyurl;
        }
        //add a short url to a entity just added to the databse
        public url addShortUrl(int id, string shortUrl)
        {
            var tinyurl = new url();
            var tinyurls = ctx.Set<url>();
            tinyurl = tinyurls.Find(id);
            tinyurl.shortUrl = shortUrl;
            ctx.SaveChanges();
            return tinyurl;
        }

    }





}
