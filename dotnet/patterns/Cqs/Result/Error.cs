using System;

namespace patterns.Cqs.Result
{
    public class Error
    {
        public Error(string message, object data = default, int? code = default)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Data = data;
            Code = code;
        }

        public int? Code { get; }
        public object Data { get; }
        public string Message { get; }
    }
}