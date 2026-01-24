namespace Okane.Application;

public abstract record Result<T>;

public record ErrorResult<T>(string Message) : Result<T>;

public record OkResult<T>(T Value) : Result<T>;