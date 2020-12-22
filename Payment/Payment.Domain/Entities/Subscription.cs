using Flunt.Validations;
using Payment.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payment.Domain.Entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payments;

        public Subscription(DateTime? expiredDate)
        {
            CreateDate = DateTime.Now;
            LastUpadateDate = DateTime.Now;
            ExpiredDate = expiredDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpadateDate { get; private set; }
        public DateTime? ExpiredDate { get; private set; }
        public bool Active { get; private set; }

        //public List<Payment> payments { get; set; }

        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "A data do pagamento deve ser futura")
                );
            
            if(Valid)
                _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            LastUpadateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpadateDate = DateTime.Now;
        }
    }
}
