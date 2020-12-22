using Payment.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, string boletoNumber, DateTime paidDate, DateTime expiredDate, decimal total, decimal totalPaid, 
                            string payer, Document document, Address address, Email email) 
            : base(paidDate, expiredDate, total, totalPaid, payer, document, address, email)
        {

            BarCode = barCode;
            BoletoNumber = boletoNumber;

        }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
    }
}
