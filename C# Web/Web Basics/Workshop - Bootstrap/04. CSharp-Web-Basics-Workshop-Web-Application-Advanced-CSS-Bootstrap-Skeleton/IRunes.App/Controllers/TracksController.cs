using IRunes.App.Extensions;
using IRunes.Models;
using IRunes.Services;
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
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;

        public TracksController()
        {
            this.trackService = new TrackService();
            this.albumService = new AlbumService();
        }

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

            string name = ((ISet<string>)this.Request.FormData["name"]).FirstOrDefault();
            string link = ((ISet<string>)this.Request.FormData["link"]).FirstOrDefault();
            string price = ((ISet<string>)this.Request.FormData["price"]).FirstOrDefault();

            var trackFromContext = new Track
            {
                Name = name,
                Link = link,
                Price = decimal.Parse(price),
            };

            if (!this.albumService.AddTrackToAlbum(albumId, trackFromContext))
            {
                return this.Redirect("/Albums/All");
            }

            return this.Redirect($"/Albums/Details?id={albumId}");
        }

        [Authorize]
        public ActionResult Details()
        {
            string albumId = this.Request.QueryData["albumId"].ToString();
            string trackId = this.Request.QueryData["trackId"].ToString();

            var trackFromContext = trackService
                    .GetTrackById(trackId);

            if (trackFromContext == null)
            {
                return this.Redirect($"/Albums/Details?id={albumId}");
            }

            this.ViewData["AlbumId"] = albumId;
            this.ViewData["Track"] = trackFromContext.ToHtmlDetails(albumId);

            return this.View();
        }
    }
}
