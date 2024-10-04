namespace PatiVerCore.Domain.Common.Result
{
    public class Result<T>
    {
        public string Message { get; private set; }
        public bool isSuccess { get; private set; }
        public T Data { get; private set; }
        public ErrorType ErrorType { get; private set; }
        public Exception Exception { get; private set; }

        #region Success Methods 
        public static Result<T> Success()
        {
            return new Result<T>
            {
                isSuccess = true
            };
        }

        public static Result<T> Success(string message)
        {
            return new Result<T> { isSuccess = true, Message = message };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T> { isSuccess = true, Data = data };
        }

        public static Result<T> Success(T data, string message)
        {
            return new Result<T> { isSuccess = true, Message =  message, Data = data };
        }

        #endregion

        #region Failure Methods
        public static Result<T> Failure()
        {
            return new Result<T> { isSuccess = false };
        }

        public static Result<T> Failure(ErrorType errorType)
        {
            return new Result<T> { isSuccess = false, ErrorType = errorType };
        }

        public static Result<T> Failure(ErrorType errorType, string message)
        {
            return new Result<T> { isSuccess = false, ErrorType = errorType, Message = message };
        }

        public static Result<T> Failure(ErrorType errorType, T data)
        {
            return new Result<T> { isSuccess = false, ErrorType = errorType, Data = data };
        }

        public static Result<T> Failure(ErrorType errorType, T data, string message)
        {
            return new Result<T> { isSuccess = false, ErrorType = errorType, Message = message, Data = data };
        }

        public static Result<T> Failure(ErrorType errorType, Exception exception)
        {
            return new Result<T> { isSuccess = false, ErrorType = errorType, Exception = exception };
        }

        public static Result<T> Failure(ErrorType errorType, Exception exception, string message)
        {
            return new Result<T> { isSuccess = false, ErrorType = errorType, Exception = exception, Message = message };
        }

        #endregion
    }
}
