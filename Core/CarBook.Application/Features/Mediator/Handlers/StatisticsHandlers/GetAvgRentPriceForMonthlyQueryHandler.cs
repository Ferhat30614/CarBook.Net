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
    public class GetAvgRentPriceForMonthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgRentPriceForMonthlyQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetAvgRentPriceForMonthlyQueryHandler(IStatisticRepository statisticRepository)
        {
            _repository = statisticRepository;
        }

        public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAvgRentPriceForMonthly();
            return new GetAvgRentPriceForMonthlyQueryResult
            {
                AvgRentPriceForMonthly = values
            };
        }
    }
}
