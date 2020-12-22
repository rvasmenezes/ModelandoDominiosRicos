using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Entities;
using Payment.Domain.Enum;
using Payment.Domain.ValueObjects;
using System;

namespace Payment.Test.Entities
{
    [TestClass]
    public class StudentTests
    {

        private readonly Document _document;
        private readonly Name _name;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        public StudentTests()
        {
            _name = new Name("Rafael", "Menezes");
            _document = new Document("12512791718", EDocumentType.CPF);
            _email = new Email("rvasmenezes@gmail.com");
            _address = new Address("Rua 1", "12", "Porto", "SG", "RJ", "BR", "24321");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void Deve_retornar_erro_quando_ja_existir_inscricao_ativa()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Fulano", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void Deve_retornar_erro_quando_tiver_inscricao_sem_pagamento()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void Deve_retornar_sucesso_quando_nao_tiver_inscricao_ativa()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Fulano", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}
