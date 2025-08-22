using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace APILern.Application.DTO.ProductCategory.Validators
{
    public class AddProductCategoryDtoValidator : AbstractValidator<AddProductCategoryDto>
    {
        public AddProductCategoryDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Категория обязательна")
                .MinimumLength(4).WithMessage("Минимум 4 символа")
                .MaximumLength(50).WithMessage("Максимум 50 символов")
                .Matches(@"[a-zA-z-а-яА-Я]").WithMessage("Название должно содержать буквы");
        }
    }
}