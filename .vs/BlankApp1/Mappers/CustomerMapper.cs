using BlankApp1.Dto;
using BlankApp1.Interfaces;
using BlankApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlankApp1.Mappers
{
    public class CustomerMapper : IModelMapper<Customer, CustomerRequestDto>
    {
        public CustomerRequestDto Map(Customer source)
        {
            if (source == null)
            {
                return null;
            }

            return new CustomerRequestDto
            {
                CustomerId = source.CustomerId,
                CompanyName = source.CompanyName,
                Name = source.Name,
                Email = source.Email,
                Phone = source.Phone
            };
        }

        public IEnumerable<CustomerRequestDto> Map(IEnumerable<Customer> source)
        {
            return source == null ? new List<CustomerRequestDto>() : source.Select(Map);
        }

        public Customer ReverseMap(CustomerRequestDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Customer
            {
                CustomerId = dto.CustomerId,
                Name = dto.Name,
                CompanyName = dto.CompanyName,
                Email = dto.Email,
                Phone = dto.Phone
            };
        }

        public IEnumerable<Customer> ReverseMap(IEnumerable<CustomerRequestDto> dto)
        {
            return dto == null ? new List<Customer>() : dto.Select(ReverseMap);
        }
    }
}
