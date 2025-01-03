using FastEndpoints;
using FluentValidation;

namespace Martix.Api.Features;

internal sealed class Request
{
    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public List<string> Tags { get; set; } = [];
}

sealed internal class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is Required.")
            .MinimumLength(10)
            .WithMessage("Title Too Short")
            .MaximumLength(50)
            .WithMessage("Title too long");

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is Required.")
            .MinimumLength(10)
            .WithMessage("Content Too Short")
            .MaximumLength(1000)
            .WithMessage("Content too long");
    }
}