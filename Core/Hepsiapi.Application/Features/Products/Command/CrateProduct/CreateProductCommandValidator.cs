﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiapi.Application.Features.Products.Command.CrateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Başlık");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Açıklama");

            RuleFor(x => x.BrandId)
                .NotEmpty()
                .WithName("Marka");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("fiyat");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .WithName("İndirim oranı");


            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any())
                .WithName("Kategoriler");


        }
    }
}
