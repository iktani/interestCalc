using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InterestCalc;
using System.Collections.Generic;

namespace InterestCalcTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCase1()
        {
            // Arrange
            // Test Case 1: 1 person, 1 wallet, 3 cards (1 Visa, 1 MC, 1 Discover)
            Card card1Visa = new Card("Visa", 100);
            Card card2MC = new Card("MC", 100);
            Card card3Discover = new Card("Discover", 100);
            List<Card> cardsForWallet1 = new List<Card>
            {
                card1Visa,
                card2MC,
                card3Discover
            };
            Wallet wallet1 = new Wallet(cardsForWallet1);
            List<Wallet> walletsForPerson1 = new List<Wallet>
            {
                wallet1
            };
            Person person1 = new Person(walletsForPerson1);

            // Act

            var card1Interest = card1Visa.CardInterestTotal;
            var card2Interest = card2MC.CardInterestTotal;
            var card3Interest = card3Discover.CardInterestTotal;
            var person1Interest = person1.PersonTotalInterest;

            // Assert

            Assert.AreEqual(card1Interest, 10);
            Assert.AreEqual(card2Interest, 5);
            Assert.AreEqual(card3Interest, 1);
            Assert.AreEqual(person1Interest, 16);
        }

        [TestMethod]
        public void TestCase2()
        {
            // Arrange
            //Test Case 2: 1 person, 2 wallets - wallet 1(card 1 Visa, card 2 Discover), wallet 2(card 1 MC, card 2 MC)
            Card card1Visa = new Card("Visa", 100);
            Card card2Discover = new Card("Discover", 100);
            List<Card> cardsForWallet1 = new List<Card>
            {
                card1Visa,
                card2Discover
            };
            Wallet wallet1 = new Wallet(cardsForWallet1);

            Card card3MC = new Card("MC", 100);
            Card card4MC = new Card("MC", 100);
            List<Card> cardsForWallet2 = new List<Card>
            {
                card3MC,
                card4MC
            };
            Wallet wallet2 = new Wallet(cardsForWallet2);

            List<Wallet> walletsForPerson1 = new List<Wallet>
            {
                wallet1,
                wallet2
            };
            Person person1 = new Person(walletsForPerson1);

            // Act

            var wallet1Interest = wallet1.WalletTotalInterest;
            var wallet2Interest = wallet2.WalletTotalInterest;
            var person1Interest = person1.PersonTotalInterest;

            // Assert

            Assert.AreEqual(wallet1Interest, 11);
            Assert.AreEqual(wallet2Interest, 10);
            Assert.AreEqual(person1Interest, 21);

        }

        [TestMethod]
        public void TestCase3()
        {
            // Arrange
            //Test Case 3: 2 persons, 1 wallet each
            // person 1 - wallet 1(card 1 MC, card 2 MC)
            // person 2 - wallet 1(card 1 Visa, card 2 MC)
            Card card1MC = new Card("MC", 100);
            Card card2MC = new Card("MC", 100);
            List<Card> cardsForWallet1 = new List<Card>
            {
                card1MC,
                card2MC
            };
            Wallet wallet1 = new Wallet(cardsForWallet1);
            List<Wallet> walletsForPerson1 = new List<Wallet>
            {
                wallet1
            };
            Person person1 = new Person(walletsForPerson1);

            Card card3MC = new Card("Visa", 100);
            Card card4MC = new Card("MC", 100);
            List<Card> cardsForWallet2 = new List<Card>
            {
                card3MC,
                card4MC
            };
            Wallet wallet2 = new Wallet(cardsForWallet2);
            List<Wallet> walletsForPerson2 = new List<Wallet>
            {
                wallet2
            };
            Person person2 = new Person(walletsForPerson2);


            // Act

            var person1Interest = person1.PersonTotalInterest;
            var person2Interest = person2.PersonTotalInterest;
            var wallet1Interest = wallet1.WalletTotalInterest;
            var wallet2Interest = wallet2.WalletTotalInterest;

            // Assert

            Assert.AreEqual(wallet1Interest, 10);
            Assert.AreEqual(person1Interest, 10);
            Assert.AreEqual(wallet2Interest, 15);
            Assert.AreEqual(person2Interest, 15);
        }
    }
}
