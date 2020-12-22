using Flunt.Validations;
using Payment.Domain.ValueObjects;
using Payment.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Payment.Domain.Entities
{
    public class Student : Entity
    {

        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }

        //O private não permite que nenhum metodo de fora possa mudar o valor da propriedade
        //public string FirstName { get; private set; }
        //public string LastName { get; private set; }
        
        public Document Document { get; private set; }
        //public string Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }

        //Errado! Desta forma permite que o estudante tenha várias inscrições e foge da regra.
        //public List<Subscription> Subscriptions { get; set; }

        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        //Anti corrupção
        public void AddSubscription(Subscription subscription)
        {

            var hasSubscriptionActive = false;

            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma conta ativa")
                .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription", "Efetue o pagamento para se inscrever")
            );

            //Alternativa
            //if (hasSubscriptionActive)
            //    AddNotification("Student.Subscription", "Você já tem uma conta ativa");

            //se ja tiver uma assinatura ativa, cancela.
            //foreach (var sub in Subscriptions)
            //{
            //    sub.Inactivate();
            //}

            _subscriptions.Add(subscription);

        }
    }
}
