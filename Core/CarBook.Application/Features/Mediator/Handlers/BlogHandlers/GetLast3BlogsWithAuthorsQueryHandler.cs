using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;
        private readonly IGenericRepository<Comment> _commentRepository;

        public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository repository, IGenericRepository<Comment> commentRepository)
        {
            _repository = repository;
            _commentRepository = commentRepository;
        }

        public async  Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {

            var values = _repository.GetLast3BlogsWithAuthors();

            return values.Select(x => new GetLast3BlogsWithAuthorsQueryResult
            {
                BlogID = x.BlogID,
                AuthorID = x.AuthorID,
                AuthorName = x.Author.Name,
                CreatedDate = x.CreatedDate,
                CategoryID = x.CategoryID,
                Title = x.Title,
                CoverImage = x.CoverImage,
                CommentCount=_commentRepository.GetCountCommentByBlog(x.BlogID)


            }).ToList();
        }
    }
}
