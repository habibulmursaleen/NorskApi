using FluentValidation;

namespace NorskApi.Application.Podcasts.Queries.GetPodcastById;

public class GetPodcastByIdQueryValidator : AbstractValidator<GetPodcastByIdQuery>
{
    public GetPodcastByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Podcast id is required.");
    }
}
