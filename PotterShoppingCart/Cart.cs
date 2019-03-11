using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace PotterShoppingCart
{
    public class Cart
    {
        private int _basicPrice = 100;

        private Dictionary<int, double> _discount = new Dictionary<int, double>
        {
            {0, 0}, {1, 1}, {2, 0.95},{3, 0.9},{4, 0.8},{5, 0.75}
        };

        public int GetTotalPrice(List<Book> books)
        {
            if (!books.Any())
            {
                return 0;
            }
            var suites = books.GroupBy(x => x.ISBN).Select(x => new { Episode = x.Key, BookCount = x.Count() });

            int totalPrice = 0;
            for (var i = 1; i <= suites.Max(x => x.BookCount); i++)
            {
                totalPrice += GetSuitePrice(suites.Where(x => x.BookCount >= i).Select(x=>x.BookCount).ToList());
            }

            return totalPrice;
        }

        private int GetSuitePrice(List<int> books)
        {
            var totalPrice = _basicPrice * books.Count;
            return (int)(totalPrice * _discount[books.Count]);
        }
    }
}