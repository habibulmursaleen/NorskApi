using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.Common.Models;
using NorskApi.Domain.EssayAggregate.ValueObjects;

namespace NorskApi.Domain.EssayAggregate.Entities;

public sealed class Roleplay : Entity<RoleplayId>
{
    public string Content { get; set; }
    public bool IsCompleted { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Roleplay() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private Roleplay(RoleplayId roleplayId, string content, bool isCompleted)
        : base(roleplayId)
    {
        this.Content = content;
        this.IsCompleted = isCompleted;
    }

    public static Roleplay Create(string content, bool isCompleted)
    {
        Roleplay roleplay = new Roleplay(RoleplayId.CreateUnique(), content, isCompleted);

        return roleplay;
    }

    public void Update(string content, bool isCompleted)
    {
        this.Content = content;
        this.IsCompleted = isCompleted;
    }

    public void Delete() { }
}
