using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace APILern.Application.DTO.AccountUser.Validators
{
    public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Имя пользователя обязяательно")
                .MinimumLength(2).WithMessage("Минимум 2 символа")
                .MaximumLength(20).WithMessage("Максимум 20 символов");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Пароль обязателен")
                .MinimumLength(8).WithMessage("Минимум 8 символов")
                .MaximumLength(30).WithMessage("Максимум 30 символов");
        }
    }
}