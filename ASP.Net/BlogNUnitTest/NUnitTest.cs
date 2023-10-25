using Blog.Applications.ArticleService;
using Blog.Applications.Auth;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System.Net.Sockets;

namespace BlogNUnitTest
{
    public class NUnitTest
    {
        Mock<DbSet<Auth>> mockSet = new Mock<DbSet<Auth>>();
        DbContextOptionsBuilder<BlogTestContext> optionBuilder;
        Mock<BlogTestContext> mockContext;

        [SetUp]
        public void Setup()
        {
            optionBuilder = new DbContextOptionsBuilder<BlogTestContext>();
            mockContext = new Mock<BlogTestContext>(optionBuilder.Options);
        }

        [Test]
        public void TestGetAuthList()
        {
            var data = new List<Auth>()
            {
                new Auth { Account = "AAA", Pwd = "123" },
                new Auth { Account = "BBB", Pwd = "222" },
                new Auth { Account = "CCC", Pwd = "333" },
            }.AsQueryable();

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


        [Test]
        public async Task TestCreateArticle()
        {
            // Mock 方法
            /*
            Mock<DbSet<Article>> mockSet = new Mock<DbSet<Article>>();

            DbContextOptionsBuilder<BlogTestContext> optionBuilder = new DbContextOptionsBuilder<BlogTestContext>(); ;
            Mock<BlogTestContext> mockContext = new Mock<BlogTestContext>(optionBuilder.Options);

            mockContext.Setup(m => m.Articles).Returns(mockSet.Object);
            var service = new ArticleService(mockContext.Object);
            */

            // UseInMemory 方法
            var option = new DbContextOptionsBuilder<BlogTestContext>()
                .UseInMemoryDatabase(databaseName: "BlogTest")
                .Options;
            BlogTestContext context = new BlogTestContext(option);

            var service = new ArticleService(context);

            await service.CreateArticle("DDD", "444");

            var rec = context.Articles.FirstOrDefault();
            Assert.IsNotNull(rec);
        }

        [Test]
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

            Article article = new Article() { Id = 1, Account = "SSS", Content = "eeeeeeeeeeeeee" };
            await service.UpdateArticle(article);
        }



        [Test]
        [TestCase(1)]
        [TestCase(111)]
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


        [Test]
        public void TestAdd()
        {
            var option = new DbContextOptionsBuilder<BlogTestContext>()
                .UseInMemoryDatabase(databaseName: "BlogTest")
                .Options;
            BlogTestContext context = new BlogTestContext(option);


            var service = new AuthService(context);

            int ans = service.TestAdd(2, 3);

            Assert.AreEqual(5, ans);


            Assert.Pass();
        }


        [Test]
        public void TestAddForError()
        {
            var service = new AuthService(new BlogTestContext());

            int ans = service.TestAdd(2, 3);

            Assert.AreEqual(5, ans);


            Assert.Pass();
        }
    }
}