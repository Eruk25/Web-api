using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace APILern.Application.DTO.Provider.Validators
{
    public class UpdateProviderDtoValidator : AbstractValidator<UpdateProviderDto>
    {
        public UpdateProviderDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Название поставщика обязательно")
                .MaximumLength(2).WithMessage("Минимум 2 символа")
                .MaximumLength(100).WithMessage("Максимум 100 символов");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email обязателен")
                .EmailAddress().WithMessage("Неверный формат email");
            RuleFor(x => x.NumberPhone)
                .NotEmpty().WithMessage("Номер телефона обязателен")
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .WithMessage("Неверный формат телефона. Пример: +375291234567");
        }
    }
}