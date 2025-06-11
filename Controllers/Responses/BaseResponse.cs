namespace Api.Controllers.Responses;

public record BaseResponse(
    string Message,
    object? Value = null
)
{}