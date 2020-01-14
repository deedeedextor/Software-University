using IRunes.App.Extensions;
using IRunes.Data;
using IRunes.Models;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Result;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        [Authorize]
        public ActionResult Create()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();

            this.ViewData["AlbumId"] = albumId;
            return this.View();
        }

        [Authorize]
        [HttpPost(ActionName = "Create")]
        public ActionResult CreateConfirm()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();

            using (var context = new RunesDbContext())
            {
                var albumFromContext = context
                    .Albums
                    .SingleOrDefault(album => album.Id == albumId);

                if (albumFromContext == null)
                {
                    return this.Redirect("/Albums/All");
                }

                string name = ((ISet<string>)this.Request.FormData["name"]).FirstOrDefault();
                string link = ((ISet<string>)this.Request.FormData["link"]).FirstOrDefault();
                string price = ((ISet<string>)this.Request.FormData["price"]).FirstOrDefault();

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

        [Authorize]
        public ActionResult Details()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();
            string trackId = this.Request.QueryData["trackId"].ToString();

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
