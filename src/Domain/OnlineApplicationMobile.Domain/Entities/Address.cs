using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineApplicationMobile.Domain.Entities
{
    /// <summary>
    /// Модель Адреса.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Уникальный идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Адресный объект.
        /// </summary>
        public AddressingObject AddressingObject { get; set; }

        /// <summary>
        /// Номер дома.
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Номер квартиры.
        /// </summary>
        public string NumberApartament { get; set; }

        /// <summary>
        /// Возвращает массив адресных объектов начиная с родительского.
        /// </summary>
        /// <returns>Массив адресных объектов начиная с родительского</returns>
        public AddressingObject[] GetAddressingObjects()
        {
            if (AddressingObject == null)
                return new AddressingObject[0];

            var addressingObjects = new List<AddressingObject>();
            addressingObjects.Add(AddressingObject);

            var parentAddressingObject = AddressingObject.Parent;
            while (parentAddressingObject != null)
            {
                addressingObjects.Add(parentAddressingObject);
                parentAddressingObject = parentAddressingObject.Parent;
            }

            addressingObjects.Reverse();

            return addressingObjects.ToArray();
        }

        /// <summary>
        /// Возвращает полную строку адреса.
        /// </summary>
        /// <returns>Полная строка адреса.</returns>
        public string GetFullToString()
        {
            var addressingObjects = GetAddressingObjects();

            if (!addressingObjects.Any() || addressingObjects == null)
                return string.Empty;

            var str = string.Empty;

            foreach (var addrObj in addressingObjects)
                str += $"{addrObj?.Type?.Name ?? string.Empty} {addrObj?.Name ?? string.Empty}, ";

            if (!string.IsNullOrWhiteSpace(HouseNumber))
                str += $"дом {HouseNumber}";

            if (!string.IsNullOrWhiteSpace(NumberApartament))
                str += $", квартира {NumberApartament}";

            return str;
        }

        /// <summary>
        /// Возвращает сокращенную строку адреса.
        /// </summary>
        /// <returns>Сокращённая строка адреса.</returns>
        public string GetShortToString()
        {
            var addressingObjects = GetAddressingObjects();

            if (!addressingObjects.Any() || addressingObjects == null)
                return string.Empty;

            var str = string.Empty;

            foreach (var addrObj in addressingObjects)
                str += $"{addrObj?.Type?.ShortName ?? string.Empty} {addrObj?.Name ?? string.Empty}, ";

            if (!string.IsNullOrWhiteSpace(HouseNumber))
                str += $"д. {HouseNumber}";

            if (!string.IsNullOrWhiteSpace(NumberApartament))
                str += $", кв. {NumberApartament}";

            return str;
        }
    }
}
