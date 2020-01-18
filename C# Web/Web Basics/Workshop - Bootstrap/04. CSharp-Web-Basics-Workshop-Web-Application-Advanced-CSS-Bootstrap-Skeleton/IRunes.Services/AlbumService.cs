using IRunes.Data;
using IRunes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.Services
{
    public class AlbumService : IAlbumService
    {
        private RunesDbContext context;

        public AlbumService()
        {
            this.context = new RunesDbContext();
        }

        public bool AddTrackToAlbum(string albumId, Track trackFromContext)
        {
            var albumFromContext = this
                       .GetAlbumById(albumId);

            if (albumFromContext == null)
            {
                return false;
            }
           
            albumFromContext.Tracks.Add(trackFromContext);
            albumFromContext.Price = (albumFromContext.Tracks
                .Select(track => track.Price)
                .Sum() * 87) / 100;

            this.context.Update(albumFromContext);
            this.context.SaveChanges();

            return true;
        }

        public Album CreateAlbum(Album album)
        {
            album = context.Albums.Add(album).Entity;
            context.SaveChanges();

            return album;
        }

        public Album GetAlbumById(string id)
        {
            return context.Albums
                .Include(album => album.Tracks)
                .SingleOrDefault(album => album.Id == id);
        }

        public ICollection<Album> GetAllAlbums()
        {
            return context.Albums.ToList();
        }
    }
}
