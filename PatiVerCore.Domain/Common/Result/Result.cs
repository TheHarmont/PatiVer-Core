namespace PatiVerCore.Domain.Common.Result
{
    public class Result<T>
    {
        public string Message { get; }
        public bool isSuccess { get; }
        public T Data { get; }
        public ErrorType ErrorType { get; }
        public Exception Exception { get;  }

        #region Non Async Methods 

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

        #endregion

        #endregion

        #region Async Methods 

        #region Success Methods 

        public static Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<Result<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }

        #endregion

        #region Failure Methods 

        public static Task<Result<T>> FailureAsync(ErrorType errorType)
        {
            return Task.FromResult(Failure(errorType));
        }

        public static Task<Result<T>> FailureAsync(ErrorType errorType, string message)
        {
            return Task.FromResult(Failure(errorType, message));
        }

        public static Task<Result<T>> FailureAsync(ErrorType errorType, T data)
        {
            return Task.FromResult(Failure(errorType, data));
        }

        public static Task<Result<T>> FailureAsync(ErrorType errorType, T data, string message)
        {
            return Task.FromResult(Failure(errorType, data, message));
        }

        public static Task<Result<T>> FailureAsync(ErrorType errorType, Exception exception)
        {
            return Task.FromResult(Failure(errorType, exception));
        }

        #endregion

        #endregion
    }
}
