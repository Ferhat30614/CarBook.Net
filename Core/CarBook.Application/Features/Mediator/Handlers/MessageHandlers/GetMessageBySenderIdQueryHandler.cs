using CarBook.Application.Features.Mediator.Queries.MessageQueries;
using CarBook.Application.Features.Mediator.Results.MessageResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Application.Interfaces.MessageInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.MessageHandlers
{
    public class GetMessageBySenderIdQueryHandler : IRequestHandler<GetMessageBySenderIdQuery, List<GetMessageBySenderIdQueryResult>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IRepository<AppUser> _appUserRepository;

        public GetMessageBySenderIdQueryHandler(IMessageRepository messageRepository, IRepository<AppUser> appUserRepository)
        {
            _messageRepository = messageRepository;
            _appUserRepository = appUserRepository;
        }

        public async Task<List<GetMessageBySenderIdQueryResult>> Handle(GetMessageBySenderIdQuery request, CancellationToken cancellationToken)
        {
            var OtherUser = await _appUserRepository.GetByIdAsync(request.SenderId);
            var message = _messageRepository.GetMessageBySenderId(request.SenderId, request.ReceiverId);

            if(message==null || !message.Any()) //message.Any()  herhangi bir eleman veya üstü sayıda eleman varsa ilgikli listenin true döner .  null ile eleman sayısı 0 farklı şeylerdeir
            {
                return new List<GetMessageBySenderIdQueryResult>
                {
                    new GetMessageBySenderIdQueryResult
                    {
                        OtherUserName = OtherUser.UserName,
                    }

                };

            }
            else
            {

                return message.Select(a => new GetMessageBySenderIdQueryResult
                {
                    SenderID = a.SenderID,
                    ReceiverID = a.ReceiverID,
                    Content = a.Content,
                    CreatedDate = a.CreatedDate,
                    ReadStatus = a.ReadStatus,
                    MessageID = a.MessageID,
                    OtherUserName = OtherUser.UserName,

                }).ToList();


            }

        }
    }
}
