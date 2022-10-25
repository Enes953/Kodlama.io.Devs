using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQueryHandler : IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
    {
        private readonly IOperationClaimRepository _operationClaimRepository;
        private readonly IMapper _mapper;

        public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
        {
            _operationClaimRepository = operationClaimRepository;
            _mapper = mapper;
        }
        public async Task<OperationClaimListModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
        {
            var operationClaims = await _operationClaimRepository.GetListAsync(index: request.PageRequest.Page,
                                                                               size: request.PageRequest.PageSize,
                                                                               cancellationToken: cancellationToken);
            var operationClaimListModel = _mapper.Map<OperationClaimListModel>(operationClaims);
            return operationClaimListModel;
        }
    }
}
