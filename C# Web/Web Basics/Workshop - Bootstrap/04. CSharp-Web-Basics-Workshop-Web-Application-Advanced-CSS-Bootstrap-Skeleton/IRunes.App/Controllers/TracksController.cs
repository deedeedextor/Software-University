using IRunes.App.ViewModels.Tracks;
using IRunes.Models;
using IRunes.Services;
using SIS.MvcFramework;
using SIS.MvcFramework.Attributes.Http;
using SIS.MvcFramework.Attributes.Security;
using SIS.MvcFramework.Mapping;
using SIS.MvcFramework.Result;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;

        public TracksController(ITrackService trackService, IAlbumService albumService)
        {
            this.trackService = trackService;
            this.albumService = albumService;
        }

        [Authorize]
        public ActionResult Create(string albumId)
        {
            return this.View(new TrackCreateViewModel {AlbumId = albumId});
        }

        [Authorize]
        [HttpPost(ActionName = "Create")]
        public ActionResult CreateConfirm(TrackCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            var trackFromContext = ModelMapper.ProjectTo<Track>(model);

            if (!this.albumService.AddTrackToAlbum(model.AlbumId, trackFromContext))
            {
                return this.Redirect("/Albums/All");
            }

            return this.Redirect($"/Albums/Details?id={model.AlbumId}");
        }

        [Authorize]
        public ActionResult Details(TrackDetailsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Redirect($"Albums/All");
            }

            var trackFromContext = this.trackService
                    .GetTrackById(model.TrackId);

            if (trackFromContext == null)
            {
                return this.Redirect($"/Albums/Details?id={model.AlbumId}");
            }

            TrackDetailsViewModel trackDetailsViewModel = ModelMapper.ProjectTo<TrackDetailsViewModel>(trackFromContext);

            trackDetailsViewModel.AlbumId = model.AlbumId;

            return this.View(trackDetailsViewModel);
        }
    }
}
