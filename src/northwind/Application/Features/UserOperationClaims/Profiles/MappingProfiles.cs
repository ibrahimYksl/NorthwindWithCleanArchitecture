using Application.Features.UserOperationClaims.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<UserOperationClaim, UserOperationClaimToAddDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreatedUserOperationClaimDto>().ReverseMap();

            //
        }
    }

}
