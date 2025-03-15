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
    public class GetCarCountByTranmissionIsAutoQueryHandler : IRequestHandler<GetCarCountByTranmissionIsAutoQuery, GetCarCountByTranmissionIsAutoQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarCountByTranmissionIsAutoQueryHandler(IStatisticRepository statisticRepository)
        {
            _repository = statisticRepository;
        }

        public async Task<GetCarCountByTranmissionIsAutoQueryResult> Handle(GetCarCountByTranmissionIsAutoQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarCountByTranmissionIsAuto();
            return new GetCarCountByTranmissionIsAutoQueryResult
            {
                CarCountByTranmissionIsAuto = values
            };
        }
    }
}
