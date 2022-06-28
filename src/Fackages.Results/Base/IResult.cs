namespace Fackages.Results.Base
{
    public interface IResult
    {
        int HttpStatusCode { get; }
        bool IsSuccess { get; }
        int Code { get; }
        string? Message { get; }
    }
}