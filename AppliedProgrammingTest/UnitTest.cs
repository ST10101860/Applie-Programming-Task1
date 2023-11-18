using AppliedProgrammingTask1.Model;
using AppliedProgrammingTask1.Models;
using AppliedProgrammingTask1.Pages;
using Microsoft.AspNetCore.SignalR;
using System.Net;

namespace AppliedProgrammingTest
{
    public class UnitTest
    {
        [Fact]
        public void HashPassword()
        {
            var hash = new Change();
            string password = "12345";

            var hashedPassword = hash.getHash(password);
            Assert.NotEmpty(hash.getHash(password));
            Assert.NotEqual("12345", hashedPassword);
        }
        [Fact]
        public void AdminLogin()
        {

            //Arrange & act
            var admin = new Admin { email = "admin@gmail.com", psw = "admin" };
            //Assert
            Assert.NotNull(admin);
            Assert.Equal("admin@gmail.com", admin.email);
            Assert.Equal("admin", admin.psw);
            //
            Assert.NotEmpty(admin.psw);
            Assert.NotEmpty(admin.email);
            Assert.Contains("@", admin.email);
            Assert.StrictEqual("admin@gmail.com", admin.email);

        }

        [Fact]
        public void GetAssignedItem()
        {
            var item = new GetAssignedItem { Id = "1", goodsSelection = "Wood" };
            Assert.NotNull(item);
            Assert.NotEmpty(item.Id);
            Assert.NotEmpty(item.goodsSelection);
            Assert.Equal("1", item.Id);
            Assert.Equal("Wood", item.goodsSelection);
        }

        [Fact]
        public void GetAssignMoney()
        {
            var item = new GetAssignMoney { Id = "1", tot = 5000, totalDonation = 70000 };
            Assert.NotNull(item);
            Assert.NotEmpty(item.Id);
            Assert.Equal("1", item.Id);
            Assert.Equal(70000, item.totalDonation);
            Assert.Equal(5000, item.tot);
        }

        [Fact]
        public void GetDisaster()
        {
            var dis = new GetDisaster { Id = "1", goodsSelection = "Wood", disasterDescription = "Flood", disasterEndDate = "20 January 2024", disasterStartDate = "20 January 2023", disasterLocation = "KZN", status = "Active" };
            Assert.NotNull(dis);
            Assert.NotEmpty(dis.Id);
            Assert.NotEmpty(dis.goodsSelection);
            Assert.NotEmpty(dis.disasterDescription);
            Assert.NotEmpty(dis.status);
            Assert.NotEmpty(dis.disasterEndDate);
            Assert.NotEmpty(dis.disasterLocation);
            Assert.NotEmpty(dis.disasterStartDate);

            Assert.Equal("Wood", dis.goodsSelection);
            Assert.Equal("Flood", dis.disasterDescription);
            Assert.Equal("Active", dis.status);
            Assert.Equal("20 January 2024", dis.disasterEndDate);
            Assert.Equal("KZN", dis.disasterLocation);
            Assert.Equal("20 January 2023", dis.disasterStartDate);
        }
        [Fact]
        public void GetGoods()
        {
            var goods = new GetGoods { date = "2023-November-20", goodDescription = "Wood", goodsSelection = "Woods", Id = "1", otherGoods = "N/A", status = "Yes", totalItem = 40 };
            Assert.NotNull(goods);
            Assert.NotEmpty(goods.Id);
            Assert.NotEmpty(goods.goodsSelection);
            Assert.NotEmpty(goods.goodDescription);
            Assert.NotEmpty(goods.status);
            Assert.NotEmpty(goods.date);
            Assert.NotEmpty(goods.otherGoods);

            Assert.Equal("2023-November-20", goods.date);
            Assert.Equal("Wood", goods.goodDescription);
            Assert.Equal("Woods", goods.goodsSelection);
            Assert.Equal("N/A", goods.otherGoods);
            Assert.Equal("Yes", goods.status);
            Assert.Equal(40, goods.totalItem);
        }

        [Fact]
        public void GetMoney()
        {
            var money = new GetMoney
            { id = "1", date = "2023-November-20", status = "Yes", totalDonation = 70000 };

            Assert.NotNull(money);
            Assert.NotEmpty(money.id);
            Assert.NotEmpty(money.status);
            Assert.NotEmpty(money.date);
            Assert.Equal("2023-November-20", money.date);
            Assert.Equal("Yes", money.status);
            Assert.Equal(70000, money.totalDonation);

        }

        [Fact]
        public void TestPublicPage()
        {
            var pub = new getPublic
            {
                startDate = "20 January 2023",
                endDate = "20 January 2024",
                description = "Rain",
                location = "KZN",
                item = "Goods",
                aid = "Goods",
                money = "5000"
            };

            Assert.NotNull(pub);
            Assert.NotEmpty(pub.aid);
            Assert.NotEmpty(pub.startDate);
            Assert.NotEmpty(pub.endDate);
            Assert.NotEmpty(pub.description);
            Assert.NotEmpty(pub.money);
            Assert.NotEmpty(pub.item);
            Assert.NotEmpty(pub.location);

            Assert.Equal("20 January 2023", pub.startDate);
            Assert.Equal("20 January 2024", pub.endDate);
            Assert.Equal("Rain", pub.description);
            Assert.Equal("KZN", pub.location);
            Assert.Equal("Goods", pub.item);
            Assert.Equal("Goods", pub.aid);
            Assert.Equal("5000", pub.money);
        }

        [Fact]
        public void PostAssignItemToDisaster()
        {
            var post = new PostAssignedItem { goodsSelection = "Wood" };

            Assert.NotNull(post);
            Assert.NotEmpty(post.goodsSelection);
            Assert.Equal("Wood", post.goodsSelection);
        }

        [Fact]
        public void PostAssignMoneyToDisaster()
        {
            var post = new PostAssignMoney { totalDonation = 70000 };

            Assert.NotNull(post);
            Assert.Equal(70000, post.totalDonation);
        }

        [Fact]
        public void PostBuyGoodsWithAvailableMoney()
        {
            var post = new PostBuy { goodsSelection = "Water", totalDonation = 50000 };

            Assert.NotNull(post);
            Assert.Equal(50000, post.totalDonation);
            Assert.Equal("Water", post.goodsSelection);
        }
        [Fact]
        public void PostDisasterToDatabase()
        {
            var dis = new PostDisaster { goodsSelection = "Wood", disasterDescription = "Flood", disasterEndDate = "20 January 2024", disasterStartDate = "20 January 2023", disasterLocation = "KZN", status = "Active" };
            Assert.NotNull(dis);
            Assert.NotEmpty(dis.goodsSelection);
            Assert.NotEmpty(dis.disasterDescription);
            Assert.NotEmpty(dis.status);
            Assert.NotEmpty(dis.disasterEndDate);
            Assert.NotEmpty(dis.disasterLocation);
            Assert.NotEmpty(dis.disasterStartDate);

            Assert.Equal("Wood", dis.goodsSelection);
            Assert.Equal("Flood", dis.disasterDescription);
            Assert.Equal("Active", dis.status);
            Assert.Equal("20 January 2024", dis.disasterEndDate);
            Assert.Equal("KZN", dis.disasterLocation);
            Assert.Equal("20 January 2023", dis.disasterStartDate);
        }

        [Fact]
        public void PostGoodsToDatabase()
        {
            var goods = new GetGoods { date = "2023-November-20", goodDescription = "Wood", goodsSelection = "Woods", Id = "1", otherGoods = "N/A", status = "Yes", totalItem = 40 };
            Assert.NotNull(goods);
            Assert.NotEmpty(goods.Id);
            Assert.NotEmpty(goods.goodsSelection);
            Assert.NotEmpty(goods.goodDescription);
            Assert.NotEmpty(goods.status);
            Assert.NotEmpty(goods.date);
            Assert.NotEmpty(goods.otherGoods);

            Assert.Equal("2023-November-20", goods.date);
            Assert.Equal("Wood", goods.goodDescription);
            Assert.Equal("Woods", goods.goodsSelection);
            Assert.Equal("N/A", goods.otherGoods);
            Assert.Equal("Yes", goods.status);
            Assert.Equal(40, goods.totalItem);
        }
        [Fact]
        public void PostMoneyToDatabase()
        {
            var item = new GetAssignMoney { Id = "1", tot = 5000, totalDonation = 70000 };
            Assert.NotNull(item);
            Assert.NotEmpty(item.Id);
            Assert.Equal("1", item.Id);
            Assert.Equal(70000, item.totalDonation);
            Assert.Equal(5000, item.tot);
        }
    }
}