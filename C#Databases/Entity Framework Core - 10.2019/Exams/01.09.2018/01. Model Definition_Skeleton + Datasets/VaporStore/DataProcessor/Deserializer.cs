namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
	{
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfullAddedGame = "Added {0} ({1}) with {2} tags";
        private const string SuccessfullAddedUserWithCards = "Imported {0} with {1} cards";
        private const string SuccessfullAddedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var gamesDto = JsonConvert.DeserializeObject<ImportGameDto[]>(jsonString);

            List<Game> games = new List<Game>();
            List<Developer> developers = new List<Developer>();
            List<Genre> genres = new List<Genre>();
            List<Tag> tags = new List<Tag>();

            StringBuilder sb = new StringBuilder();

            foreach (var gameDto in gamesDto)
            {
                var isGameValid = IsValid(gameDto);
                var isTagsValid = gameDto.Tags.Any(t => !IsValid(t));

                if (!isGameValid || isTagsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var developer = developers
                    .FirstOrDefault(d => d.Name == gameDto.Developer);

                if (developer == null)
                {
                    developer = new Developer
                    {
                        Name = gameDto.Developer
                    };

                    developers.Add(developer);
                }

                Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

                if (genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };

                    genres.Add(genre);
                }

                List<Tag> gameTags = new List<Tag>();

                foreach (var tagName in gameDto.Tags)
                {
                    var tag = tags.FirstOrDefault(t => t.Name == tagName);

                    if (tag == null)
                    {
                        tag = new Tag
                        {
                            Name = tagName
                        };
                    }

                    tags.Add(tag);
                    gameTags.Add(tag);
                }

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    Developer = developer,
                    Genre = genre,
                    GameTags = gameTags.Select(t => new GameTag { Tag = t }).ToList()
                };

                games.Add(game);

                sb.AppendLine(string.Format(SuccessfullAddedGame, game.Name, game.Genre.Name, gameTags.Count()));
            }

            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var usersDto = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString);

            var users = new List<User>();

            var sb = new StringBuilder();

            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);

                var isUserValid = IsValid(user);
                var hasCards = userDto.Cards.Count >= 1;
                var isCardValid = userDto.Cards.Any(c => !IsValid(c));

                if (!isUserValid || !hasCards || isCardValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                /*foreach (var cardDto in userDto.Cards)
                {
                    var card = Mapper.Map<Card>(cardDto);
                    user.Cards.Add(card);
                }*/

                users.Add(user);

                sb.AppendLine(string.Format(SuccessfullAddedUserWithCards, user.Username, user.Cards.Count()));
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var purchases = new List<Purchase>();

            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(ImportPurchaseDto[]), new XmlRootAttribute("Purchases"));

            var purchasesDto = (ImportPurchaseDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var purchaseDto in purchasesDto)
            {
                var purchase = Mapper.Map<Purchase>(purchaseDto);

                var isPurchaseValid = IsValid(purchase);
                var targetCard = context.Cards
                    .FirstOrDefault(c => c.Number == purchaseDto.CardNumber);
                var targetGame = context.Games
                    .FirstOrDefault(g => g.Name == purchaseDto.Title);

                if (!isPurchaseValid || targetCard == null || targetGame == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                purchase.Card = targetCard;
                purchase.Game = targetGame;

                var targetUser = context.Users
                    .FirstOrDefault(u => u.Id == targetCard.UserId);

                purchases.Add(purchase);
                sb.AppendLine(string.Format(SuccessfullAddedPurchase, targetGame.Name, targetUser.Username));
            }

            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
		}

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}