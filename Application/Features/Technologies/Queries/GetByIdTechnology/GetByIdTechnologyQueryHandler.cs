using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetByIdTechnology
{
    public class GetByIdTechnologyQueryHandler : IRequestHandler<GetByIdTechnologyQuery, TechnologyGetByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _technologyRepository;
        private readonly TechnologyBusinessRules _technologyBusinessRules;

        public GetByIdTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
        {
            _mapper = mapper;
            _technologyRepository = technologyRepository;
            _technologyBusinessRules = technologyBusinessRules;
        }

        public async Task<TechnologyGetByIdDto> Handle(GetByIdTechnologyQuery request, CancellationToken cancellationToken)
        {
            Technology? technology = await _technologyRepository.Query().Include(t => t.ProgrammingLanguage).FirstOrDefaultAsync(x => x.Id == request.Id);

            //Technology? technology = await _technologyRepository.GetAsync(t => t.Id == request.Id);  
            _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);
            TechnologyGetByIdDto mappedtechnologyGetByIdDto = _mapper.Map<TechnologyGetByIdDto>(technology);
            return mappedtechnologyGetByIdDto;
        }
    }
}
