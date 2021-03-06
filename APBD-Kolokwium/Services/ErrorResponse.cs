﻿namespace Services
{
    public class ErrorResponse : IResponseModel
    {
        public ErrorResponse(string message)
        {
            Message = message;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Error;
        public string Message { get; set; }
        public object Result { get; set; } = null;
    }
}
