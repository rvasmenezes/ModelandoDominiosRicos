using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Entities;
using Payment.Domain.Enum;
using Payment.Domain.Queries;
using Payment.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payment.Test.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {

        private IList<Student> _students = new List<Student>();

        public StudentQueriesTests()
        {
            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(
                        new Name("Aluno", "Sobrenome" + i.ToString()),
                        new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                        new Email(i.ToString() + "@oi.com")
                    ));
            }

        }

        [TestMethod]
        public void Deve_retornar_null_quando_documento_nao_existir()
        {

            var exp = StudentQueries.GetStudentInfo("12345678911");
            var stud = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, stud);
        }

        [TestMethod]
        public void Deve_retornar_student_quando_documento_existir()
        {

            var exp = StudentQueries.GetStudentInfo("11111111111");
            var stud = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, stud);
        }

    }
}
