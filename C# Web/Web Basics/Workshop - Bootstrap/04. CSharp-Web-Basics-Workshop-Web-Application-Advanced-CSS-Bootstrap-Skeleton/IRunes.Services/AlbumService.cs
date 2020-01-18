using IRunes.Data;
using IRunes.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
