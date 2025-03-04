using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAllBlogsWithAuthorsQueryHandler : IRequestHandler<GetAllBlogsWithAuthorsQuery, List<GetAllBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorsQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllBlogsWithAuthorsQueryResult>> Handle(GetAllBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {

            var values = _repository.GetAllBlogsWithAuthors();

            return values.Select(x => new GetAllBlogsWithAuthorsQueryResult
            {
                BlogID = x.BlogID,
                AuthorID = x.AuthorID,
                AuthorName = x.Author.Name,
                CreatedDate = x.CreatedDate,
                CategoryID = x.CategoryID,   
                Title = x.Title,
                CoverImage = x.CoverImage,


            }).ToList();
        }
    }
}
