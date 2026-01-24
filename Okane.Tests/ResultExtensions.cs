using Okane.Application;

namespace Okane.Tests;

public static class ResultExtensions
{
    public static T AssertOk<T>(this Result<T> result)
    {
        var okResult = Assert.IsType<OkResult<T>>(result);
        return okResult.Value;
    }
    
    public static string AssertError<T>(this Result<T> result)
    {
        var okResult = Assert.IsType<ErrorResult<T>>(result);
        return okResult.Message;
    }
}