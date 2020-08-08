using System;
using System.Collections.Generic;
using MongoDB.Driver;
using PirateStoryTimeV2.Models;

namespace PirateStoryTimeV2.Services
{
    public class CardService
    {
        private readonly IMongoCollection<Card> _cards;

        public CardService(IPirateStoryTimeDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _cards = database.GetCollection<Card>(settings.CardCollectionName);
        }

        public List<Card> Get() =>
          _cards.Find(Card => true).ToList();

        public Card Get(string id) =>
            _cards.Find<Card>(Card => Card.Id == id).FirstOrDefault();

        public Card Create(Card Card)
        {
            _cards.InsertOne(Card);
            return Card;
        }

        public void Update(string id, Card CardIn) =>
            _cards.ReplaceOne(Card => Card.Id == id, CardIn);

        public void Remove(Card CardIn) =>
            _cards.DeleteOne(Card => Card.Id == CardIn.Id);

        public void Remove(string id) =>
            _cards.DeleteOne(Card => Card.Id == id);
    }
}
