using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void GetTotalPrize_Buy_Nothing_Should_return_0()
        {
            var books = new List<Book>();
            TotalPrizeShouldBe(0, books);
        }

        [TestMethod]
        public void GetTotalPrize_Buy_One_EP1_Should_return_100()
        {
            var books = new List<Book> { new Book() { ISBN = "1" } };
            TotalPrizeShouldBe(100, books);
        }

        [TestMethod]
        public void GetTotalPrize_Buy_Two_Different_Episode_Should_return_190()
        {
            var books = new List<Book> { new Book() { ISBN = "1" }, new Book() { ISBN = "2" } };
            TotalPrizeShouldBe(190, books);
        }

        [TestMethod]
        public void GetTotalPrize_Buy_Three_Different_Episode_Should_return_270()
        {
            var books = new List<Book>
            {
                new Book() { ISBN = "1" },
                new Book() { ISBN = "2" },
                new Book() { ISBN = "3" },
            };
            TotalPrizeShouldBe(270, books);
        }

        [TestMethod]
        public void GetTotalPrize_Buy_Four_Different_Episode_Should_return_320()
        {
            var books = new List<Book>
            {
                new Book() { ISBN = "1" },
                new Book() { ISBN = "2" },
                new Book() { ISBN = "3" },
                new Book() { ISBN = "4" },
            };
            TotalPrizeShouldBe(320, books);
        }

        [TestMethod]
        public void GetTotalPrize_Buy_Five_Different_Episode_Should_return_375()
        {
            var books = new List<Book>
            {
                new Book() { ISBN = "1" },
                new Book() { ISBN = "2" },
                new Book() { ISBN = "3" },
                new Book() { ISBN = "4" },
                new Book() { ISBN = "5" },
            };
            TotalPrizeShouldBe(375, books);
        }
        [TestMethod]
        public void GetTotalPrize_Buy_two_Ep1_and_Ep2_Should_return_290()
        {
            var books = new List<Book>
            {
                new Book() { ISBN = "1" },
                new Book() { ISBN = "2" },
                new Book() { ISBN = "1" },
            };
            TotalPrizeShouldBe(290, books);
        }
        private static void TotalPrizeShouldBe(int expected, List<Book> books)
        {
            var cart = new Cart();
            var actual = cart.GetTotalPrize(books);
            Assert.AreEqual(expected, actual);
        }
    }
}
