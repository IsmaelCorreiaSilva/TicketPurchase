
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
                .Length(5,100).WithMessage("O título não pode ser vázio");

            RuleFor(c => c.Description)
                .NotEmpty()
                .Length(5, 100).WithMessage("O título não pode ser vázio");

            RuleFor(c => c.Date)
                .NotNull().WithMessage("A data do evento não ser nula");
        }
    }
}
