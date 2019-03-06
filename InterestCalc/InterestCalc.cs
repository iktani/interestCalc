using System;
using System.Collections.Generic;
using System.Linq;

namespace InterestCalc
{
    public class InterestCalc
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Card
    {
        public string CardType { get; set; } 
        public double CardBalance { get; set; }
        public double CardInterestTotal { get; set; } 

        public Card(string cardType, double cardBalance)
        {
            CardType = cardType;
            CardBalance = cardBalance;
            CardInterestTotal = CalcInterest();
        }

        public int GetRate(string CardType)
        {
            switch (CardType)
            {
                case "Visa":
                    return 10;
                case "MC":
                    return 5;
                case "Discover":
                    return 1;
                default:
                    return 0;
            }
        }

        public double CalcInterest()
        {
            return (CardBalance * (GetRate(CardType)/100.0));
        }
    }
    public class Wallet
    {
        public List<Card> Cards { get; set; }
        public double WalletTotalInterest { get; set; } 

        public Wallet(List<Card> cards)
        {
            Cards = cards;
            WalletTotalInterest = WalletTotalInterestCalc(cards);
        }

        public double WalletTotalInterestCalc(List<Card> cards)
        {
            return cards.Sum(c => c.CardInterestTotal);
        }
    }

    public class Person
    {
        public List<Wallet> Wallets { get; set; }
        public double PersonTotalInterest { get; set; }

        public Person(List<Wallet> wallets)
        {
            Wallets = wallets;
            PersonTotalInterest = PersonTotalInterestCalc(wallets);
        }

        public double PersonTotalInterestCalc(List<Wallet> wallets)
        {
            return wallets.Sum(w => w.WalletTotalInterest);
        }
    }
}
