using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Commands;
using Payment.Domain.Enum;
using Payment.Domain.Handlers;
using Payment.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Test.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {

        [TestMethod]
        public void deve_retornar_erro_quando_documento_existe()
        {

            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Rafael";
            command.LastName = "Menezes";
            command.Document = "99999999999";
            command.Email = "rvasmenezes@gmail.com2";
            command.BarCode = "123135";
            command.BoletoNumber = "321";
            command.PaymentNumber = "84846846";
            command.PaidDate = DateTime.Now;
            command.ExpiredDate = DateTime.Now;
            command.Total = 100;
            command.TotalPaid = 55;
            command.Payer = "Eu";
            command.PayerDocument = "1231351";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "OI@OI";
            command.Street = "Rua 1";
            command.Number = "22";
            command.Neighborhood = "Porto ";
            command.City = "SG";
            command.State = "RJ";
            command.Country = "BR";
            command.ZipCode = "2132";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}
