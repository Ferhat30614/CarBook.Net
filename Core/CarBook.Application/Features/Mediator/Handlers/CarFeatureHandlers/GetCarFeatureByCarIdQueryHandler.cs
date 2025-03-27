using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        public Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
