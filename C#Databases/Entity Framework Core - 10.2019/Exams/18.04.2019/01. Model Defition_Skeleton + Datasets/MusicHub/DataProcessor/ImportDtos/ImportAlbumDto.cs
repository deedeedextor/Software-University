namespace MusicHub.DataProcessor.ImportDtos
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ImportAlbumDto
    {
        [Required]
        [StringLength(40), MinLength(3)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}