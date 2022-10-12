using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string email, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = email;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;

            Portfolio = new List<Stock>();
        }
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if(stock.MarketCapitalization > 10000 && this.MoneyToInvest >= stock.PricePerShare)
            {
                this.MoneyToInvest -= stock.PricePerShare;
                this.Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var stock = this.Portfolio.Find(x => x.CompanyName == companyName);
            if (stock == null) return $"{companyName} does not exist.";
            if (sellPrice < stock.PricePerShare) return $"Cannot sell {companyName}.";

            this.Portfolio.Remove(stock);
            this.MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName) => this.Portfolio.Find(x => x.CompanyName == companyName);

        public Stock FindBiggestCompany()
        {
            if(this.Portfolio.Count == 0) return null;

            return this.Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in this.Portfolio)
                sb.AppendLine(stock.ToString());

            return sb.ToString().TrimEnd();
        }
    }
}
