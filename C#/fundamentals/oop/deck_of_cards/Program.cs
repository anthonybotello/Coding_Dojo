using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Card
        {
            private string stringVal;
            private string suit;
            private int val;

            public string StringVal
            {
                get
                {
                    return stringVal;
                }
            }
            public string Suit
            {
                get
                {
                    return suit;
                }
            }
            public int Val
            {
                get
                {
                    return val;
                }
            }

            public Card(string strval,string card_suit,int card_val)
            {
                stringVal = strval;
                suit = card_suit;
                val = card_val;
            }
        }

        class Deck
        {
            private List<Card> cards;

            public List<Card> Cards
            {
                get
                {
                    return cards;
                }
            }

            public void Init()
                {
                    cards = new List<Card>();
                    string[] card_types = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
                    string[] suits = {"Spades","Hearts","Diamonds","Clubs"};

                    foreach (string suit in suits)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            cards.Add(new Card(card_types[i],suit,i+1));
                        }
                    }
                }
            public Deck()
            {
                Init();
            }

            public Card Deal()
            {
                Card top_card = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                return top_card;
            }

            public void Reset()
            {
                Init();
            }

            public void Shuffle()
            {
                Random rand = new Random();
                List<Card> shuffled = new List<Card>();
                while (cards.Count > 0)
                {
                    int rand_idx = rand.Next(0,cards.Count);
                    shuffled.Add(cards[rand_idx]);
                    cards.RemoveAt(rand_idx);
                }
                cards = shuffled;
            }

            public void ListCards()
            {
                foreach (Card card in cards)
                {
                    Console.WriteLine($"Value: {card.Val}, Type: {card.StringVal}, Suit: {card.Suit}");
                }
                
            Console.WriteLine($"Cards in deck: {cards.Count}");
            }
        }

        class Player
        {
            private string name;
            private List<Card> hand;

            public string Name
            {
                get
                {
                    return name;
                }
            }

            public List<Card> Hand
            {
                get
                {
                    return hand;
                }
            }

            public Player(string player_name)
            {
                name = player_name;
                hand = new List<Card>();
            }

            public Card Draw(Deck deck)
            {
                Card new_card = deck.Deal();
                hand.Add(new_card);
                return new_card;
            }

            public Card Discard(int idx)
            {
                if (idx < 0 || idx >= hand.Count || hand.Count == 0)
                {
                    return null;
                }
                else
                {
                    Card discard = hand[idx];
                    hand.RemoveAt(idx);
                    return discard;
                }
            }

            public void ShowHand()
            {
                foreach (Card card in hand)
                {
                    Console.WriteLine($"Value: {card.Val}, Type: {card.StringVal}, Suit: {card.Suit}");
                }
            }
        }

    class Program
    {
        static void Main(string[] args)
        {
            //Testing properties and methods of Deck class
            Deck deck = new Deck();
            deck.ListCards();
            Card dealt_card = deck.Deal();
            Console.WriteLine($"Value: {dealt_card.Val}, Type: {dealt_card.StringVal}, Suit: {dealt_card.Suit}");
            Console.WriteLine($"Cards in deck: {deck.Cards.Count}");
            deck.Reset();
            deck.ListCards();
            deck.Shuffle();
            deck.ListCards();

            //Testing properties and methods of Player class
            Player anthony = new Player("Anthony");
            anthony.ShowHand();
            Console.WriteLine(anthony.Name);
            for (int i = 1; i <= 5; i++)
            {
                anthony.Draw(deck);
            }
            deck.ListCards();
            anthony.ShowHand();
            Console.WriteLine(anthony.Discard(-1));
            Console.WriteLine(anthony.Discard(7));
            anthony.ShowHand();
            anthony.Discard(4);
            anthony.Discard(0);
            Console.WriteLine("New hand:");
            anthony.ShowHand();
        }
    }
}
