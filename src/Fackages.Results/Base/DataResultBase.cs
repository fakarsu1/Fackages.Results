namespace Fackages.Results.Base
{
    public class DataResultBase<T> : ResultBase, IDataResult<T>
    {
        public DataResultBase(T data, bool isSuccess, int code, string message, int httpStatusCode) : base(isSuccess, code, message, httpStatusCode)
        {
            Data = data;
        }

        public T Data { get; }
    }
}