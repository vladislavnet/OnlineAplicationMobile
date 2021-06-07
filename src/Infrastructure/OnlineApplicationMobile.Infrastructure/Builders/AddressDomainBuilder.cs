using OnlineApplicationMobile.Domain.Entities;
using OnlineApplicationMobile.HttpService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineApplicationMobile.Infrastructure.Builders
{
    /// <summary>
    /// Билдер адреса из Dto
    /// </summary>
    public class AddressDomainBuilder
    {
        public Address Build(AddressDto addressDto)
        {
            if (addressDto == null)
                return null;

            var addressingObjects = new List<AddressingObject>();

            var addressingObjectDto = addressDto.AddressingObject;

            while (addressingObjectDto != null)
            {
                addressingObjects.Add(BuildAddressingObject(addressingObjectDto));
                addressingObjectDto = addressingObjectDto.Parent;
            }

            for (int i = 0; i < addressingObjects.Count - 1; i++)
            {
                addressingObjects[i].Parent = addressingObjects[i + 1];
            }



            return new Address
            {
                Id = addressDto.Id,
                AddressingObject = addressingObjects.Count > 0 ? addressingObjects[0] : null,
                NumberApartament = addressDto.NumberApartament,
                HouseNumber = addressDto.HouseNumber
            };
        }

        public AddressingObject BuildAddressingObject(AddressingObjectDto addressingObjectDto)
        {
            if (addressingObjectDto == null)
                return null;

            return new AddressingObject
            {
                Id = addressingObjectDto.Id,
                Name = addressingObjectDto.Name,
                Type = BuildTypeAddressingObject(addressingObjectDto.Type)
            };
        }

        public TypeAddressingObject BuildTypeAddressingObject(TypeAddressingObjectDto typeAddressingObjectDto)
        {
            if (typeAddressingObjectDto == null)
                return null;

            return new TypeAddressingObject
            {
                Id = typeAddressingObjectDto.Id,
                Level = BuildLevelAddressingObject(typeAddressingObjectDto.Level),
                Name = typeAddressingObjectDto.Name,
                ShortName = typeAddressingObjectDto.ShortName,
            };
        }

        public LevelAddressingObject BuildLevelAddressingObject(LevelAddressingObjectDto levelAddressingObjectDto)
        {
            if (levelAddressingObjectDto == null)
                return null;

            return new LevelAddressingObject
            {
                Id = levelAddressingObjectDto.Id,
                Name = levelAddressingObjectDto.Name,
                Level = levelAddressingObjectDto.Level
            };
        }

        public AddressDto Rebuild(Address address)
        {
            if (address == null)
                return null;

            var addressingObjectsDto = new List<AddressingObjectDto>();

            var addressingObjectDto = address.AddressingObject;

            while (addressingObjectDto != null)
            {
                addressingObjectsDto.Add(RebuildAddressingObject(addressingObjectDto));
                addressingObjectDto = addressingObjectDto.Parent;
            }

            for (int i = 0; i < addressingObjectsDto.Count - 1; i++)
            {
                addressingObjectsDto[i].Parent = addressingObjectsDto[i + 1];
            }



            return new AddressDto
            {
                Id = address.Id,
                AddressingObject = addressingObjectsDto.Count > 0 ? addressingObjectsDto[0] : null,
                NumberApartament = address.NumberApartament,
                HouseNumber = address.HouseNumber
            };
        }

        public AddressingObjectDto RebuildAddressingObject(AddressingObject addressingObject)
        {
            if (addressingObject == null)
                return null;

            return new AddressingObjectDto
            {
                Id = addressingObject.Id,
                Name = addressingObject.Name,
                Type = RebuildTypeAddressingObject(addressingObject.Type)
            };
        }

        public TypeAddressingObjectDto RebuildTypeAddressingObject(TypeAddressingObject typeAddressingObject)
        {
            if (typeAddressingObject == null)
                return null;

            return new TypeAddressingObjectDto
            {
                Id = typeAddressingObject.Id,
                Level = RebuildLevelAddressingObject(typeAddressingObject.Level),
                Name = typeAddressingObject.Name,
                ShortName = typeAddressingObject.ShortName,
            };
        }

        public LevelAddressingObjectDto RebuildLevelAddressingObject(LevelAddressingObject levelAddressingObject)
        {
            if (levelAddressingObject == null)
                return null;

            return new LevelAddressingObjectDto
            {
                Id = levelAddressingObject.Id,
                Name = levelAddressingObject.Name,
                Level = levelAddressingObject.Level
            };
        }
    }
}
