using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace APILern.Application.DTO.AccountUser.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Имя обязательно")
                .MinimumLength(2).WithMessage("Минимум 2 символа")
                .MaximumLength(20).WithMessage("Максимум 20 символов");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Фамилия обязательно")
                .MinimumLength(2).WithMessage("Минимум 2 символа")
                .MaximumLength(20).WithMessage("Максимум 20 символов");
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Имя пользователя обязяательно")
                .MinimumLength(2).WithMessage("Минимум 2 символа")
                .MaximumLength(20).WithMessage("Максимум 20 символов");
            RuleFor(x => x.NumberPhone)
                .NotEmpty().WithMessage("Номер телефона обязателен")
                .Matches(@"^\+375\s?\(?\d{2}\)?\s?\d{3}[-\s]?\d{2}[-\s]?\d{2}$")
                .WithMessage("Неверный формат номера. Пример: +375 (29) 123-45-67");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email обязателен")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
                .WithMessage("Неверный формат email");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .MinimumLength(8).WithMessage("Минимум 8 символов")
                .MaximumLength(30).WithMessage("Максимум 30 символов")
                .Matches("[A-Z]").WithMessage("Пароль должен содержать хотя бы одну заглавную букву")
                .Matches("[0-9]").WithMessage("Пароль должен содержать хотя бы одну цифру");
        }
    }
}