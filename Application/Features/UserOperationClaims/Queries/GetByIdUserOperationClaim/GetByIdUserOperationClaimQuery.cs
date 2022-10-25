using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim
{
    public class GetByIdUserOperationClaimQuery : IRequest<UserOperationClaimGetByIdDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; } ={UserOperationClaimRoles.UserOperationClaimAdmin,UserOperationClaimRoles.UserOperationClaimRead};

    }
}
