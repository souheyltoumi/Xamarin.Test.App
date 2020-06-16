using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xamarin.Test.App.Model;
namespace Xamarin.UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void HasPassword_UserHasPassword_ResultTrue()
        {
            //Arrange
            User user = new User("username", "password");

            //Act
            var result = user.HasPassword(user);
            //Asset
            Assert.IsTrue(result);

        }
        [TestMethod]
        public void HasPassword_UserHasNoPassword_ResultFalse()
        {
            //Arrange
            User user = new User("username",null);

            //Act
            var result = user.HasPassword(user);
            //Asset
            Assert.IsFalse(result);

        }
    }
}
