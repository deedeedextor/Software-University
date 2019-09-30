﻿using System;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int DefaultHealth = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, DefaultHealth)
        {
        }
    }
}
