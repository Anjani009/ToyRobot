using FluentValidation;
using Microsoft.Extensions.Options;
using ToyRobot.Models;

namespace ToyRobot.Validator
{
    public class RequestValidator: AbstractValidator<PlaceRequest>
    {
        public RequestValidator(IOptions<TableDimension> tableTopConfig)
        {
            var config = tableTopConfig.Value;
            RuleFor(model => model.direction).IsInEnum().WithMessage("Direction should be either NORTH,SOUTH,EAST,WEST");
            RuleFor(model => model.X).InclusiveBetween(0, config.Width - 1).WithMessage($"X must be between 0 and {config.Width - 1}.");
            RuleFor(model => model.Y).InclusiveBetween(0, config.Height - 1).WithMessage($"Y must be between 0 and {config.Height - 1}.");
        }
    }
}
