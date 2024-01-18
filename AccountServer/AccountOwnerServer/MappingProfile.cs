using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace AccountOwnerServer;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Owner, OwnerDto>();
        CreateMap<Account, AccountDto>();
        CreateMap<OwnerForCreationDto, Owner>();
        CreateMap<OwnerForUpdateDto, Owner>();
        CreateMap<AccountForCreationDto, Account>();
        CreateMap<AccountForUpdateDto, Account>();
    }
}