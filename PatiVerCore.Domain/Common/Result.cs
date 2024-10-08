namespace PatiVerCore.Domain.Common
{
    public class Result<T>
    {
        public T Data { get; }
        public string? ErrorMessage { get; }
        public bool IsSuccess => ErrorMessage == null;

        private Result(T? value, string? error)
        {
            Data = value;
            ErrorMessage = error;
        }

        public static Result<T> Success(T value) => new Result<T>(value, null);
        public static Result<T> Failure(string? error = null) => new Result<T>(default, error);
    }
}
