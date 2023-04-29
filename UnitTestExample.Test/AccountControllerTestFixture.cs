using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Controllers;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace UnitTestExample.Test
{
    internal class AccountControllerTestFixture
    {
        public bool CheckJelszo(string text)
        {
            // Vizsgáljuk, hogy van-e kisbetű
            if (!Regex.IsMatch(text, "[a-z]"))
            {
                return false;
            }

            // Vizsgáljuk, hogy van-e nagybetű
            if (!Regex.IsMatch(text, "[A-Z]"))
            {
                return false;
            }

            // Vizsgáljuk, hogy van-e szám
            if (!Regex.IsMatch(text, "[0-9]"))
            {
                return false;
            }

            // Vizsgáljuk, hogy csak megfelelő karakterek vannak
            if (!Regex.IsMatch(text, "^[a-zA-Z0-9]{8,}$"))
            {
                return false;
            }

            // Minden feltétel teljesül, tehát visszatérünk true értékkel
            return true;
        }



        [
       Test,
       TestCase("abcd1234", false),
       TestCase("irf@uni-corvinus", false),
       TestCase("irf.uni-corvinus.hu", false),
       TestCase("irf@uni-corvinus.hu", true)
       ]
        public void TestValidateEmail(string email, bool expectedResult)
        {
           
            // Arrange
            var accountController = new AccountController();
           

            // Act
            var actualResult = accountController.ValidateEmail(email);
            

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            
        }

        [
       Test,
       TestCase("abcd1234","assssssd", false),
       TestCase("irf@uni-corvinus","SDFFDSFSD", false),
       TestCase("irf.uni-corvinus.hu","wrwerwerwer", false),
       TestCase("irf@uni-corvinus.hu","a" ,false),
       TestCase("irf@uni-corvinus.hu", "aA12321a", true)
       ]
        public void TestValidateRegister(string email,string jelszo, bool expectedResult)
        {
            // Arrange
            var accountController = new AccountController();


            // Act
            var actualResult = accountController.Register(email,jelszo);
            

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }


        [
        Test,
        TestCase("irf@uni-corvinus.hu", "Abcd1234"),
        TestCase("irf@uni-corvinus.hu", "Abcd1234567"),
]
        public void TestRegisterHappyPath(string email, string password)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            var actualResult = accountController.Register(email, password);

            // Assert
            Assert.AreEqual(email, actualResult.Email);
            Assert.AreEqual(password, actualResult.Password);
            Assert.AreNotEqual(Guid.Empty, actualResult.ID);
     
        }

        [
    Test,
    TestCase("irf@uni-corvinus", "Abcd1234"),
    TestCase("irf.uni-corvinus.hu", "Abcd1234"),
    TestCase("irf@uni-corvinus.hu", "abcd1234"),
    TestCase("irf@uni-corvinus.hu", "ABCD1234"),
    TestCase("irf@uni-corvinus.hu", "abcdABCD"),
    TestCase("irf@uni-corvinus.hu", "Ab1234"),
]
        public void TestRegisterValidateException(string email, string password)
        {
            // Arrange
            var accountController = new AccountController();

            // Act
            try
            {
                var actualResult = accountController.Register(email, password);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                //Assert.IsInstanceOf<ValidationException>(ex);
            }



            // Assert
        }
    }
}
