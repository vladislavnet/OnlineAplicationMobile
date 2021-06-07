using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OnlineApplicationMobile.Infrastructure.SqlLiteData
{
    public class ConfigurationSqlLite
    {
        private const string DATABASE_NAME = "OnlineApplicationDB.db";
        private string databasePath;

        public string DatabasePath => Path.Combine(databasePath, DATABASE_NAME);

        public void SetDataBasePath(string path)
        {
            if (databasePath != null)
                throw new ApplicationException("У Базы данных уже установлен путь.");

            if (string.IsNullOrWhiteSpace(path))
                throw new ApplicationException("Путь до БД не должен быть пустым");

            databasePath = path;
        }
    }
}
