using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Podcasts.Commands.UpdatePodcast;

public class UpdatePodcastValidator : AbstractValidator<UpdatePodcastCommand>
{
    public UpdatePodcastValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");

        RuleFor(x => x.EssayId)
            .Must(x => x == null || x != Guid.Empty)
            .WithMessage("EssayId must be a valid guid.");

        RuleFor(x => x.Label)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Label is required with max 255 character.");

        RuleFor(x => x.Descriptions)
            .MaximumLength(500)
            .WithMessage("Descriptions must be under 500 characters.");

        RuleFor(x => x.Logo).NotEmpty().WithMessage("Logo is required.");

        RuleFor(x => x.Url)
            .NotEmpty()
            .WithMessage("Url is required.")
            .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
            .WithMessage("Url is not a valid URL.")
            .MaximumLength(255)
            .WithMessage("Url must not exceed 255 characters.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.IsFeatured).NotNull().WithMessage("IsFeatured is required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");
    }
}
