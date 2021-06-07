using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Domain.Exeptions
{
    public class EntityNullReferenceExeption : DomainException
    {
        public EntityNullReferenceExeption(string message) : base(message)
        {
        }
    }
}
