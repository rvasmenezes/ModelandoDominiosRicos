using Payment.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardHolderName, string cardNumber, string lastTransactionNumber, DateTime paidDate, DateTime expiredDate, 
                                decimal total, decimal totalPaid, string payer, Document document, Address address, Email email) 
            : base(paidDate, expiredDate, total, totalPaid, payer, document, address, email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        //Precisa do gatway do cartão de crédito
        public string CardHolderName { get; set; }

        //ultimos 4 numeros do cartão
        public string CardNumber { get; set; }

        public string LastTransactionNumber { get; set; }
    }
}
