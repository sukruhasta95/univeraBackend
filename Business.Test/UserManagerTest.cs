using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Business.Test
{
    [TestClass]
    public class UserManagerTest
    {
        private readonly IUserDal userDal;

        [TestMethod]
        public void tum_kullanicilar_listenmelidir()
        {
            //arrange
            IUserService userService = new UserManager(userDal);

            //act
            var user1 = userService.GetAll();

            //assert
            Assert.AreEqual(1, user1.Count);
        }
    }
}
