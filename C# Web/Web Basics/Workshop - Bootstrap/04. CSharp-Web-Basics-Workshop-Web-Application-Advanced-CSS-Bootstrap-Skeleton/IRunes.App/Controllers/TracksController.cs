using IRunes.App.Extensions;
using IRunes.Data;
using IRunes.Models;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        public IHttpResponse Create(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            string albumId = httpRequest.QueryData["albumId"].ToString();

            this.ViewData["AlbumId"] = albumId;
            return this.View();
        }

        [HttpPost(ActionName = "Create")]
        public IHttpResponse CreateConfirm(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            string albumId = httpRequest.QueryData["albumId"].ToString();

            using (var context = new RunesDbContext())
            {
                var albumFromContext = context
                    .Albums
                    .SingleOrDefault(album => album.Id == albumId);

                if (albumFromContext == null)
                {
                    return this.Redirect("/Albums/All");
                }

                string name = ((ISet<string>)httpRequest.FormData["name"]).FirstOrDefault();
                string link = ((ISet<string>)httpRequest.FormData["link"]).FirstOrDefault();
                string price = ((ISet<string>)httpRequest.FormData["price"]).FirstOrDefault();

                var trackFromContext = new Track
                {
                    Name = name,
                    Link = link,
                    Price = decimal.Parse(price),
                };

                albumFromContext.Tracks.Add(trackFromContext);
                albumFromContext.Price = (albumFromContext.Tracks
                    .Select(track => track.Price)
                    .Sum() * 87) / 100;

                context.Update(albumFromContext);
                context.SaveChanges();
            }

            return this.Redirect($"/Albums/Details?id={albumId}");
        }

        public IHttpResponse Details(IHttpRequest httpRequest)
        {
            if (!this.IsLoggedIn(httpRequest))
            {
                return this.Redirect("/Users/Login");
            }

            string albumId = httpRequest.QueryData["albumId"].ToString();
            string trackId = httpRequest.QueryData["trackId"].ToString();

            using (var context = new RunesDbContext())
            {
                var trackFromContext = context
                    .Tracks
                    .SingleOrDefault(track => track.Id == trackId);

                if (trackFromContext == null)
                {
                    return this.Redirect($"/Albums/Details?id={albumId}");
                }

                this.ViewData["AlbumId"] = albumId;
                this.ViewData["Track"] = trackFromContext.ToHtmlDetails(albumId);
            }

            return this.View();
        }
    }
}
