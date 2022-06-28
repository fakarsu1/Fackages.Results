namespace Fackages.Results.Base
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}