using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Domain.Enums
{
    /// <summary>
    /// Статус заявки.
    /// </summary>
    public enum StatusApplication
    {
        Create = 1,
        Accept = 2,
        Complete = 3,
        Cancel = 4,
        Revoke = 5,
        Refuse = 6,
        Undefined = 99,
    }
}
