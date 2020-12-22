using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Shared.Commands
{
    public interface ICommand
    {
        void Validate();
    }
}
