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
                    return "Принята";
                case StatusApplication.Complete:
                    return "Выполнена";
                case StatusApplication.Cancel:
                    return "Отменена";

                default:
                    return "Неизвестно";
            }
        }
    }
}
