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
        Undefined = 99,
    }
}
