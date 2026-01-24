using Okane.Application;

namespace Okane.WebApi;

public static class ResultExtensions
{
    public static IResult ToHttpResult<T>(this Result<T> result) =>
        result switch
        {
            ErrorResult<T> errorResult => Results.BadRequest(errorResult.Message),
            OkResult<T> okResult => Results.Ok(okResult.Value),
            _ => throw new ArgumentOutOfRangeException(nameof(result))
        };
}