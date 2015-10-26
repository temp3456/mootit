using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mootit.Users.Tests
{
    [TestClass]
    public class DataModelTests
    {
        [TestMethod]
        [TestCategory("DAL")]
        [Description("This test will validate a simple connection and it will try to list all available customers")]
        public void Validate_1()
        {
            using (Service.Accounts accounts = new Service.Accounts())
            {
                var customer = accounts.GetCustomer(1);
            }
        }

        [TestMethod]
        [TestCategory("DAL")]
        [Description("This test will validate the insert for new customers")]
        public void Validate_2()
        {
            using (Service.Accounts accounts = new Service.Accounts())
            {
                var customer = accounts.InsertCustomer(new Entities.Customer()
                {
                    User = new Entities.User()
                    {
                        Username = "andre"
                    },
                    Address = "Barueri, SP (Brasil)",
                    PhoneNumer = 9,
                    Fullname = "André Alberto Furlan"
                });
            }
        }
    }
}
