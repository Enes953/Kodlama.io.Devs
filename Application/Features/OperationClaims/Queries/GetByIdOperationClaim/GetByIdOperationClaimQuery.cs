using Application.Features.OperationClaims.Constants;
using Application.Features.OperationClaims.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery:IRequest<OperationClaimGetByIdDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } ={OperationClaimRoles.OperationClaimAdmin,OperationClaimRoles.OperationClaimRead};
    }
}
