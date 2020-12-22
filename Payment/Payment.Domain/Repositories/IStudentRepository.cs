using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Repositories
{
    public interface IStudentRepository
    {
        //Repository Pattern
        bool DocumentExists(string document);

        bool EmailExists(string email);

        void CreateSubscription(Student student);
    }
}
