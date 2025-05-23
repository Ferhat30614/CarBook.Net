﻿using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAuthorQueryHandler:IRequestHandler<GetBlogQuery,List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;
        public GetAuthorQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetAllAsync(); 
            return values.Select(x=> new GetBlogQueryResult
            {           
                
                BlogID = x.BlogID,               
                AuthorID = x.AuthorID,
                CategoryID = x.CategoryID,
                Title = x.Title,
                CoverImage = x.CoverImage,
                CreatedDate = x.CreatedDate,
                

            }).ToList();
        }
    }
}
