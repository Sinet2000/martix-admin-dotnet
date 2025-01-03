using FastEndpoints;
using Martix.Domain.Entities;

namespace Martix.Api.Features;

sealed internal class Mapper : Mapper<Request, Response, StoryEntity>
{
    public override StoryEntity ToEntity(Request r) => new()
    {
        Title = r.Title,
        Content = r.Content,
        Tags = r.Tags
    };
}