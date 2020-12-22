using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Test.Commands
{

    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {

        [TestMethod]
        public void deve_retornar_erro_com_firstname_vazio()
        {

            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            command.Validate();
            Assert.AreEqual(false, command.Valid);
        }

    }
}
