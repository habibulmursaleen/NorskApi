namespace NorskApi.Domain.Common.Models;

public interface IHasTimeStamp
{
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }
}
