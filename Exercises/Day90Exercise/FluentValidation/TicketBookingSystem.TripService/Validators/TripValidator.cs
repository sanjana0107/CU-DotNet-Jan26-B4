using FluentValidation;
using TicketBookingSystem.TripService.Models;
namespace TicketBookingSystem.TripService.Validators
{
    public class TripValidator : AbstractValidator<Trip>
    {
        public TripValidator()
        {
            RuleFor(t => t.Heading)
            .NotEmpty().WithMessage("Heading is required")
            .MaximumLength(100);

            RuleFor(t => t.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(t => t.Nights)
                .GreaterThan(0);

            RuleFor(t => t.StartDate)
                .LessThan(t => t.EndDate)
                .WithMessage("StartDate must be before EndDate");
        }
    }
}
