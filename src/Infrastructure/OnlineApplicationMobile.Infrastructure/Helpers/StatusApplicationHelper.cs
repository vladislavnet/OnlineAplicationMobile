using OnlineApplicationMobile.Domain.Enums;

namespace OnlineApplicationMobile.Infrastructure.Helpers
{
    public static class StatusApplicationHelper
    {
        public static StatusApplication GetStatusApplicationByInteger(int status)
        {
            switch (status)
            {
                case 1:
                    return StatusApplication.Create;
                case 2:
                    return StatusApplication.Accept;
                case 3:
                    return StatusApplication.Complete;
                case 4:
                    return StatusApplication.Cancel;
                case 5:
                    return StatusApplication.Revoke;
                case 6:
                    return StatusApplication.Refuse;

                default:
                    return StatusApplication.Undefined;
            }
        }

        public static string GetStatusApplicationString(StatusApplication status)
        {
            switch (status)
            {
                case StatusApplication.Create:
                    return "Создана";
                case StatusApplication.Accept:
                    return "В работе";
                case StatusApplication.Complete:
                    return "Выполнена";
                case StatusApplication.Cancel:
                    return "Отменена";
                case StatusApplication.Revoke:
                    return "Отозвана";
                case StatusApplication.Refuse:
                    return "Отказано";

                default:
                    return "Неизвестно";
            }
        }
    }
}
