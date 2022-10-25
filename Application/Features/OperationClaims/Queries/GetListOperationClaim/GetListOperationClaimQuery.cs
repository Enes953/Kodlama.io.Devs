using Application.Features.OperationClaims.Constants;
using Application.Features.OperationClaims.Models;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery : IRequest<OperationClaimListModel>, ISecuredRequest
    {
        public PageRequest PageRequest { get; set; }

        public string[] Roles { get; } = { OperationClaimRoles.OperationClaimAdmin, OperationClaimRoles.OperationClaimRead };
    }
}