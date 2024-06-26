﻿using Application.Common.Exceptions;
using Application.Repositories;
using Application.Services.IndustryServices.Command.GetAllIndustryQuery;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IndustryServices.Command.GetAllIndustryQuery
{
    public class GetAllIndustryHandler : IRequestHandler<GetAllIndustryRequest, List<GetAllIndustryResponse>>
    {
        protected readonly IIndustryRepository _industryRepository;
        protected readonly IMapper _mapper;
        public GetAllIndustryHandler(IIndustryRepository industryRepository, IMapper mapper)
        {
            _industryRepository = industryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllIndustryResponse>> Handle(GetAllIndustryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Industry> list;
                if (string.IsNullOrEmpty(request.Search))
                {
                    list = await _industryRepository.GetAll(cancellationToken);
                }
                else
                {
                    list = await _industryRepository.SearchByIndustry(request.Search, cancellationToken);
                }
                return _mapper.Map<List<GetAllIndustryResponse>>(list);
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
