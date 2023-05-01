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
      TestCase("Abcdasdf", false),
      TestCase("ABCDET2DA", false),
      TestCase("ysdgsdh213", false),
      TestCase("ABcd23", false),
      TestCase("aAbbccdd23", true)
      ]
        public void TestValidatePassword(string password, bool expectedResult)
        {

            // Arrange
            var accountController = new AccountController();


            // Act
            var actualResult = accountController.ValidatePassword(password);


            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
  }

