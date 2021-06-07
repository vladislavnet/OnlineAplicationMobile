using System;
using System.Collections.Generic;
using System.Text;
using OnlineApplicationMobile.Domain.Enums;

namespace OnlineApplicationMobile.HttpService.DTO.Builders
{
    public class AddressDtoBuilder
    {
        /// <summary>
        /// Формирует адрес для пользователя.
        /// </summary>
        /// <param name="region">Регион</param>
        /// <param name="district">Район.</param>
        /// <param name="locality">Населённый пункт.</param>
        /// <param name="street">Улица.</param>
        /// <param name="houseNumber">Номер дома.</param>
        /// <param name="appartamentNumber">Номер квартиры.</param>
        /// <returns></returns>
        public AddressDto BuildAddUserAddress(AddUserAddress address)
        {
            return new AddressDto
            {
                AddressingObject = new AddressingObjectDto
                {
                    Name = address.Street,
                    Type = address.TypeStreet,
                    Parent = new AddressingObjectDto
                    {
                        Name = address.Locality,
                        Type = address.TypeLocality,
                        Parent = new AddressingObjectDto
                        {
                            Name = address.District,
                            Type = address.TypeDistrict,
                            Parent = new AddressingObjectDto
                            {
                                Name = address.Region,
                                Type = address.TypeRegion
                            }
                        }
                    }
                },
                HouseNumber = address.NumberHouse,
                NumberApartament = address.ApartamentNumber
            };
        }


        public class AddUserAddress
        {
            public TypeAddressingObjectDto TypeRegion { get; set; }
            public string Region { get; set; }
            public TypeAddressingObjectDto TypeDistrict { get; set; }
            public string District { get; set; }
            public TypeAddressingObjectDto TypeLocality { get; set; }
            public string Locality { get; set; }
            public TypeAddressingObjectDto TypeStreet { get; set; }
            public string Street { get; set; }
            public string NumberHouse { get; set; }
            public string ApartamentNumber { get; set; }
        }
    }
}
