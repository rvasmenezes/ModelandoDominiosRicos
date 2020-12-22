using Payment.Domain.Repositories;
using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Test.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            
        }

        public bool DocumentExists(string document)
        {
            if (document == "99999999999")
                return true;

            return false;
            
        }

        public bool EmailExists(string email)
        {
            if (email == "rvasmenezes@gmail.com")
                return true;

            return false;
        }
    }
}
