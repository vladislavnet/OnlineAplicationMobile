using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Domain.Exeptions
{
    public abstract class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
