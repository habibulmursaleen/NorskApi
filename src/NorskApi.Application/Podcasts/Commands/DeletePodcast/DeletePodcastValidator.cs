using FluentValidation;

namespace NorskApi.Application.Podcasts.Commands.DeletePodcast;

public class DeletePodcastValidator : AbstractValidator<DeletePodcastCommand>
{
    public DeletePodcastValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");
    }
}
