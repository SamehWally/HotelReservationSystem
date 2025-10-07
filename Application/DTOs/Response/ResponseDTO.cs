using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs.Response
{
    public class ResponseDTO<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public static ResponseDTO<T> Success(T data, string message = "Operation successful")
        => new ResponseDTO<T> { IsSuccess = true, Message = message, Data = data ,ErrorCode=ErrorCode.NoError};

        public static ResponseDTO<T> Failure(ErrorCode errorCode,string message)
            => new ResponseDTO<T> { IsSuccess = false, Message = message, Data = default ,ErrorCode=errorCode};
    }
}
