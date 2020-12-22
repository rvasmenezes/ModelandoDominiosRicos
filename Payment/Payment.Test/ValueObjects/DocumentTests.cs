using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Enum;
using Payment.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Test.ValueObjects
{

    [TestClass]
    public class DocumentTests
    {

        [TestMethod]
        public void Deve_retornar_erro_cnpj_invalido()
        {

            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void Deve_retornar_sucesso_cnpj_valido()
        {
            var doc = new Document("51813067000186", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void Deve_retornar_erro_cpf_invalido()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("12512791718")]
        [DataRow("22456864387")]
        [DataRow("54485841871")]
        public void Deve_retornar_sucesso_cpf_valido(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
