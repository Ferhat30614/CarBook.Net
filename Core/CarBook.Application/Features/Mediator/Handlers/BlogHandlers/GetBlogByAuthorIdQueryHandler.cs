using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, GetBlogByAuthorIdQueryResult>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByAuthorIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async  Task<GetBlogByAuthorIdQueryResult> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
        {

            var values = _blogRepository.GetBlogByAuthorId(request.Id);

            return new GetBlogByAuthorIdQueryResult
            {

                BlogID = values.BlogID,
                AuthorID = values.AuthorID,
                AuthorName=values.Author.Name,
                AuthorDescription=values.Author.Description,    
                AuthorImageUrl=values.Author.ImageUrl,  
                

            };
        }
    }
}
