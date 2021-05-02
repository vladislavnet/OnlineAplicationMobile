﻿using OnlineApplicationMobile.Domain.Entities;
using OnlineApplicationMobile.Domain.Exeptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Infrastructure.Globals
{
    /// <summary>
    /// Статический класс с текущими значениями текущего пользователя.
    /// </summary>
    public static class CurrentUser
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public static Guid Id { get; private set; }

        /// <summary>
        /// Email.
        /// </summary>
        public static string Email { get; private set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public static string FirstName { get; private set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public static string LastName { get; private set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public static string MiddleName { get; private set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public static DateTime? BirthDate { get; private set; }

        /// <summary>
        /// Телефон.
        /// </summary>
        public static string Telephone { get; private set; }

        /// <summary>
        /// Является ли пользователем подтверждённым.
        /// </summary>
        public static bool IsConfirmed { get; private set; }

        /// <summary>
        /// Номер лицевого счёта.
        /// </summary>
        public static string NumberPersonalAccount { get; private set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public static Address Address { get; private set; }

        /// <summary>
        /// Токен пользователя.
        /// </summary>
        public static string Token { get; private set; }

        /// <summary>
        /// Устанавливает информацию текущего пользоваетеля.
        /// </summary>
        /// <param name="clientJKH">Клиент ЖКХ</param>
        public static void SetCurrentUser(ClientJKH clientJKH)
        {
            if (clientJKH == null || clientJKH?.User == null)
                throw new EntityNullReferenceExeption("Переданный объект пользователя явлется пустым");


            Id = clientJKH.User.Id;
            FirstName = !string.IsNullOrWhiteSpace(clientJKH.User.FirstName) ? clientJKH.User.FirstName : FirstName;
            LastName = !string.IsNullOrWhiteSpace(clientJKH.User.LastName) ? clientJKH.User.LastName : LastName;
            MiddleName = !string.IsNullOrWhiteSpace(clientJKH.User.MiddleName) ? clientJKH.User.MiddleName : MiddleName;
            BirthDate = clientJKH.User.BirthDate != null ? clientJKH.User.BirthDate : BirthDate;
            Telephone = !string.IsNullOrWhiteSpace(clientJKH.User.Telephone) ? clientJKH.User.Telephone : Telephone;
            NumberPersonalAccount = !string.IsNullOrWhiteSpace(clientJKH.NumberPersonalAccount) ? clientJKH.NumberPersonalAccount : NumberPersonalAccount;
            Address = clientJKH.Address != null ? clientJKH.Address : Address;
        }

        public static string GetAddressFullToString()
        {
            if (Address == null)
                return string.Empty;

            return Address.GetFullToString();
        }

        public static string GetAddressShortToString()
        {
            if (Address == null)
                return string.Empty;

            return Address.GetShortToString();
        }

        public static void SetToken(string token)
        {
            Token = token;
        }
    }
}