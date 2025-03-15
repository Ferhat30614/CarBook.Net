using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBrandNameByMaxCarQueryHandler : IRequestHandler<GetBrandNameByMaxCarQuery, GetBrandNameByMaxCarQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetBrandNameByMaxCarQueryHandler(IStatisticRepository statisticRepository)
        {
            _repository = statisticRepository;
        }

        public async Task<GetBrandNameByMaxCarQueryResult> Handle(GetBrandNameByMaxCarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBrandNameByMaxCar();
            return new GetBrandNameByMaxCarQueryResult
            {
                BrandNameByMaxCar = values
            };
        }
    }
    {
    }
}
