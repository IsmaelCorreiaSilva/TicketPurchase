﻿
using FluentValidation;
using TicketPurchase.Application.Models.Event;

namespace TicketPurchase.Application.Validators.Event
{
    public class EventCreateValidator : AbstractValidator<EventCreateModel>
    {
        public EventCreateValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .Length(5,100);

            RuleFor(c => c.Description)
                .NotEmpty()
                .Length(5, 100);

            RuleFor(c => c.Date)
                .NotNull();
        }
    }
}
