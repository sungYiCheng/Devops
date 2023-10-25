using Blog.Applications.ArticleService;
using Blog.Applications.Auth;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BlogMSTest
{
    [TestClass]
    public class MSUnitTest
    {
        public MSUnitTest()
        {

        }

        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            int num1 = 2;
            int num2 = 3;
            int expected = 5;

            // Act
            var service = new AuthService(new BlogTestContext());
            int ans = service.TestAdd(num1, num2);

            // Assert
            Assert.AreEqual(expected, ans);
        }

        [TestMethod]
        public void TestGetAuthList()
        {
            var data = new List<Auth>()
            {
                new Auth { Account = "AAA", Pwd = "123" },
                new Auth { Account = "BBB", Pwd = "222" },
                new Auth { Account = "CCC", Pwd = "333" },
            }.AsQueryable();

            Mock<DbSet<Auth>> mockSet = new Mock<DbSet<Auth>>();

            DbContextOptionsBuilder<BlogTestContext> optionBuilder = new DbContextOptionsBuilder<BlogTestContext>(); ;
            Mock<BlogTestContext> mockContext = new Mock<BlogTestContext>(optionBuilder.Options);


            mockSet.As<IQueryable<Auth>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Auth>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Auth>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Auth>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext.Setup(m => m.Auths).Returns(mockSet.Object);
            var service = new AuthService(mockContext.Object);

            var authList = service.GetAuthList();

            Assert.AreEqual(3, authList.Count);
            Assert.AreEqual("AAA", authList[0].Account);
            Assert.AreEqual("123", authList[0].Pwd);
            Assert.AreEqual("BBB", authList[1].Account);
            Assert.AreEqual("222", authList[1].Pwd);
        }

        [TestMethod]
        [DataRow("SSS", "dddddddddddddd")]
        [DataRow("SSS1", "dddddddddddddd2")]
        [DataRow("SSS", "dddddddddddddd3")]
        public async Task TestCreateArticle(string account, string content)
        {
            Mock<DbSet<Article>> mockSet = new Mock<DbSet<Article>>();

            DbContextOptionsBuilder<BlogTestContext> optionBuilder = new DbContextOptionsBuilder<BlogTestContext>(); ;
            Mock<BlogTestContext> mockContext = new Mock<BlogTestContext>(optionBuilder.Options);

            mockContext.Setup(m => m.Articles).Returns(mockSet.Object);
            var service = new ArticleService(mockContext.Object);

            await service.CreateArticle(account, content);

            // mockSet.Verify(m => m.Add(It.IsAny<Article>()), Times.Once());
            //mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public async Task TestUpdateArticle()
        {
            var data = new List<Article>()
            {
                new Article { Id = 1, Account = "SSS", Content = "12333333333" },
            }.AsQueryable();

            Mock<DbSet<Article>> mockSet = new Mock<DbSet<Article>>();

            DbContextOptionsBuilder<BlogTestContext> optionBuilder = new DbContextOptionsBuilder<BlogTestContext>(); ;
            Mock<BlogTestContext> mockContext = new Mock<BlogTestContext>(optionBuilder.Options);

            mockSet.As<IQueryable<Article>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Article>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Article>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Article>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext.Setup(m => m.Articles).Returns(mockSet.Object);
            var service = new ArticleService(mockContext.Object);

            Article article = new Article() {Id = 1, Account = "SSS", Content = "eeeeeeeeeeeeee" };
            await service.UpdateArticle(article);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(111)]
        public async Task TestDeleteArticle(long id)
        {
            var data = new List<Article>()
            {
                new Article { Id = 1, Account = "SSS", Content = "12333333333" },
                new Article { Id = 111, Account = "SSS", Content = "12333333333222" },
            }.AsQueryable();

            Mock<DbSet<Article>> mockSet = new Mock<DbSet<Article>>();

            DbContextOptionsBuilder<BlogTestContext> optionBuilder = new DbContextOptionsBuilder<BlogTestContext>(); ;
            Mock<BlogTestContext> mockContext = new Mock<BlogTestContext>(optionBuilder.Options);

            mockSet.As<IQueryable<Article>>().Setup(x => x.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Article>>().Setup(x => x.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Article>>().Setup(x => x.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Article>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext.Setup(m => m.Articles).Returns(mockSet.Object);
            var service = new ArticleService(mockContext.Object);

            await service.DeleteArticle(id);
        }
    }
}