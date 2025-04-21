using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidator:AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Kullanıcının adı boş geçilemez");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Bu alan en az 5 karakter olmalı");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Bu alan Boş geçilemez");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Bu alan en az 50 karakter olmalı");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Bu alan en çok 500 karakter olmalı");
        }
    }
}
