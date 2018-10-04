using Api.Customers.Application.Dto;
using AutoMapper;
using Logic.BL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Customers.Application.Assembler
{
    public class CustomerCreateAssembler
    {
        private readonly IMapper _mapper;

        public CustomerCreateAssembler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Customer toEntity(CustomerCreateDto customerCreateDto)
        {
            return _mapper.Map<Customer>(customerCreateDto);
        }
    }
}
