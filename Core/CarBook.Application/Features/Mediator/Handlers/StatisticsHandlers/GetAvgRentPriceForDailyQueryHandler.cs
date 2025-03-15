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
    public class GetAvgRentPriceForDailyQueryHandler : IRequestHandler<GetAvgRentPriceForDailyQuery, GetAvgRentPriceForDailyQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetAvgRentPriceForDailyQueryHandler(IStatisticRepository statisticRepository)
        {
            _repository = statisticRepository;
        }

        public async Task<GetAvgRentPriceForDailyQueryResult> Handle(GetAvgRentPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAvgRentPriceForDaily();
            return new GetAvgRentPriceForDailyQueryResult
            {
                AvgRentPriceForDaily = values
            };
        }
    }
}
