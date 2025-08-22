using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace APILern.Application.DTO.Product.Validators
{
    public class AddProductDtoValidator : AbstractValidator<AddProductDto>
    {
        public AddProductDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Название товара обязательно")
                .MinimumLength(2).WithMessage("Минимум 2 символа")
                .MaximumLength(100).WithMessage("Максимум 100 символов");
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Изображение обязательно");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Описание обязательно")
                .MinimumLength(30).WithMessage("Минимум 30 символов")
                .MaximumLength(5000).WithMessage("Максимум 5000 символов");
            RuleFor(x => x.Price)
                .NotNull().WithMessage("Цена обязательна")
                .GreaterThan(0).WithMessage("Цена должна быть больше 0")
                .LessThanOrEqualTo(100000)
                .WithMessage("Цена не должна быть превышать 100 000");
            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("Количество обязательно")
                .GreaterThan(0).WithMessage("Количество должно быть больше 0")
                .LessThanOrEqualTo(1000)
                .WithMessage("Количество не должно превышать 1000");
            RuleFor(x => x.ProviderId)
                .NotNull().WithMessage("Поставщик обязателен");
            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("Категория обязательна");
        }
    }
}