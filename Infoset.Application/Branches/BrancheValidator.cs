using FluentValidation;
using Infoset.Domain;

namespace Infoset.Application.Branches
{
    public class BrancheValidator : AbstractValidator<Branche>
    {
        public BrancheValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Latitude).NotEmpty();
            RuleFor(x => x.Longitude).NotEmpty();
        }
    }
}
