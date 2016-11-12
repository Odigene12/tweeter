using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweeter.DAL;
using Moq;
using System.Data.Entity;
using Tweeter.Models;
using System.Collections.Generic;
using System.Linq;

namespace Tweeter.Tests.DAL
{
    [TestClass]
    public class TweeterTests
    {
        private Mock<DbSet<ApplicationUser>> mockUsers { get; set; }
        private Mock<TweeterContext> mockContext { get; set; }
        private TweeterRepository Repo { get; set; }

        public List<ApplicationUser> users { get; set; } 

        [TestInitialize]

        public void initialize()
        {
            mockContext = new Mock<TweeterContext>();
            mockUsers = new Mock<DbSet<ApplicationUser>>();
            Repo = new TweeterRepository();

            /*
             1. Install Identity from NuGet into Tests (using statement needed)
             2. Create a mock context that uses "UserManager" instead of "TweeterContext"
             */
        }

        public void ConnectToDatabase()
        {
            users = new List<ApplicationUser>();
            var queryusers = users.AsQueryable();

            //Lie to LINQ make it think that our new Queryable List is a Database table.
            mockUsers.As<IQueryable<ApplicationUser>>().Setup(m => m.Provider).Returns(queryusers.Provider);
            mockUsers.As<IQueryable<ApplicationUser>>().Setup(m => m.Expression).Returns(queryusers.Expression);
            mockUsers.As<IQueryable<ApplicationUser>>().Setup(m => m.ElementType).Returns(queryusers.ElementType);
            mockUsers.As<IQueryable<ApplicationUser>>().Setup(m => m.GetEnumerator()).Returns(() => (queryusers.GetEnumerator()));

            //Here, Instead of using "TweeterUsers", you would use "Users"
            mockContext.Setup(c => c.ApplicationUser).Returns(mockUsers.Object);
            /*
             mock_user_manager_context.Setup(c = c.Users) Returns (mockUsers.Object)
             */

        }

        [TestMethod]
        public void RepoEnsureCanCreateInstance()
        {
            TweeterRepository repo = new TweeterRepository();

            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureICanGetUsernames()
        {
            TweeterRepository repo = new TweeterRepository();


        }
    }
}
