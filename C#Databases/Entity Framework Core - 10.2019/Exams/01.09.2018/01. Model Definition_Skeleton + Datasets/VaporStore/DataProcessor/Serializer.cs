namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.DataProcessor.ExportDto;

    public static class Serializer
	{
        public static object JSonConvert { get; private set; }

        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
            var genres = context.Genres
                    .Where(g => genreNames.Contains(g.Name))
                    .OrderByDescending(g => g.Games
                    .Where(gm => gm.Purchases.Count >= 1)
                    .Sum(s => s.Purchases.Count))
                    .ThenBy(g => g.Id)
                    .Select(g => new ExportGenreDto
                    {
                        Id = g.Id,
                        Genre = g.Name,
                        Games = g.Games.Where(gm => gm.Purchases.Count >= 1)
                         .Select(gm => new ExportGameByGenreDto
                         {
                             Id = gm.Id,
                             Title = gm.Name,
                             Developer = gm.Developer.Name,
                             Tags = string.Join(", ", gm.GameTags.Select(t => t.Tag.Name)),
                             Players = gm.Purchases.Count
                         })
                         .OrderByDescending(gm => gm.Players)
                         .ThenBy(gm => gm.Id)
                         .ToList(),
                        TotalPlayers = g.Games
                        .Where(gm => gm.Purchases.Count >= 1)
                        .Sum(p => p.Purchases.Count)
                    })
                    .ToList();

            var json = JsonConvert.SerializeObject(genres, new JsonSerializerSettings 
            { 
                Formatting = Newtonsoft.Json.Formatting.Indented
            });

            return json;
        }//10/20

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
            var users = context.Users
                .Select(u => new ExportUserDto
                {
                    Username = u.Username,
                    Purchases = u.Cards.SelectMany(p => p.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Select(p => new ExportPurchaseDto
                    {
                        Card = p.Card.Number,
                        Cvc = p.Card.Cvc,
                        Date = p.Date.ToString(@"yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                        Game = new ExportGameDto
                        {
                            Title = p.Game.Name,
                            Genre = p.Game.Genre.Name,
                            Price = p.Game.Price
                        }
                    })
                    .OrderBy(p => p.Date)
                    .ToArray(),
                    TotalSpent = u.Cards.SelectMany(c => c.Purchases)
                    .Where(p => p.Type.ToString() == storeType)
                    .Sum(p => p.Game.Price)
                })
                .Where(p => p.Purchases.Any())
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportUserDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName(),
            });

            xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}