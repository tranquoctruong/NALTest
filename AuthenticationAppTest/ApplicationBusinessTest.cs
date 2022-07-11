using AuthenticationBusiness.UserBusiness;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationAppTest
{
    [TestClass]
    public class ApplicationBusinessTest
    {
        private ApplicationBusiness _business;

        [TestInitialize]
        public void SetUp()
        {
            _business = new ApplicationBusiness();
        }

        [TestMethod]
        public void UserLoginPassTest()
        {
            Assert.IsNotNull(_business.UserLogin("quoctruong", "12345"));
        }

        [TestMethod]
        public void UserLoginFailTest()
        {
            Assert.IsNull(_business.UserLogin("xyz", "12345"));
        }

        [TestMethod]
        public void ValidateUserPassTest()
        {
            Assert.AreEqual(true, _business.ValidateExistUser("quoctruong"));
        }

        [TestMethod]
        public void ValidateUserFailTest()
        {
            Assert.AreEqual(false, _business.ValidateExistUser("xyz"));
        }

        [TestMethod]
        public void UserSignUpPassTest()
        {
            Assert.IsNotNull(_business.UserSignUp("quoctruong5", "12345", 0));
        }

        [TestMethod]
        public void UserSignUpFailTest()
        {
            Assert.IsNull(_business.UserSignUp("xyz", "12345", 5));
        }
    }
}
