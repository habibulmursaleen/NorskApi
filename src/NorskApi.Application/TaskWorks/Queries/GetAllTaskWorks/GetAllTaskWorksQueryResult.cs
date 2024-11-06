using NorskApi.Application.TaskWorks.Models;

namespace NorskApi.Application.TaskWorks.Queries.GetAllTaskWorks;

public record GetAllTaskWorkQueryResult(List<TaskWorkResult> TaskWorks);
