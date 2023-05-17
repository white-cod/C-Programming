using System;
using System.Collections.Generic;

namespace PokerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Poker Game!");

            // Initialize the deck of cards
            Deck deck = new Deck();
            deck.Shuffle();

            // Initialize players
            List<Player> players = new List<Player>();
            players.Add(new Player("Player 1"));
            players.Add(new Player("Player 2"));

            // Deal cards to players
            for (int i = 0; i < 5; i++)
            {
                foreach (Player player in players)
                {
                    Card card = deck.Draw();
                    player.Hand.Add(card);
                }
            }

            // Show hands of players
            foreach (Player player in players)
            {
                Console.WriteLine(player.Name + ": " + player.Hand.ToString());
            }

            // Determine the winner
            int winnerIndex = 0;
            int highestRank = 0;
            for (int i = 0; i < players.Count; i++)
            {
                int rank = players[i].Hand.Rank();
                if (rank > highestRank)
                {
                    highestRank = rank;
                    winnerIndex = i;
                }
            }

            Console.WriteLine("\n" + players[winnerIndex].Name + " wins with " + Hand.RankToString(highestRank) + "!");
        }
    }

    class Card
    {
        public enum Suit { Spades, Hearts, Clubs, Diamonds };
        public enum Rank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };

        public Suit CardSuit { get; set; }
        public Rank CardRank { get; set; }

        public Card(Suit suit, Rank rank)
        {
            CardSuit = suit;
            CardRank = rank;
        }

        public override string ToString()
        {
            return CardRank.ToString() + " of " + CardSuit.ToString();
        }
    }

    class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            foreach (Card.Suit suit in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Rank rank in Enum.GetValues(typeof(Card.Rank)))
                {
                    Card card = new Card(suit, rank);
                    cards.Add(card);
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int r = i + random.Next(cards.Count - i);
                Card temp = cards[r];
                cards[r] = cards[i];
                cards[i] = temp;
            }
        }

        public Card Draw()
        {
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }

    class Hand
    {
        public List<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void Add(Card card)
        {
            Cards.Add(card);
        }

        public int Rank()
        {
            // Implement your own ranking algorithm here
            // This example returns a random rank between 0 and 9
            Random random = new Random();
            return random.Next(10);
        }

        public override string ToString()
        {
            string str = "";
            foreach (Card card in Cards)
            {
                str += card.ToString() + ", ";
            }
            return str.TrimEnd(',', ' ');
        }

        public static string RankToString(int rank)
        {
            switch (rank)
            {
                case 0: return "High Card";
                case 1: return "One Pair";
                case 2: return "Two Pair";
                case 3: return "Three of a Kind";
                case 4: return "Straight";
                case 5: return "Flush";
                case 6: return "Full House";
                case 7: return "Four of a Kind";
                case 8: return "Straight Flush";
                case 9: return "Royal Flush";
                default: return "Unknown Rank";
            }
        }
    }

    class Player
    {
        public string Name { get; set; }
        public Hand Hand { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new Hand();
        }
    }
}