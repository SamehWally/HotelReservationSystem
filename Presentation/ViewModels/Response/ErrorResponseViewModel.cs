using Domain.Enums;
using Presentation.ViewModels.Response;
using EnumContainer = Domain.Enums;

namespace Presentation.ViewModels
{
    public class ErrorResponseViewModel<T> : ResponseViewModel<T>
    {
        public ErrorResponseViewModel(ErrorCode errorCode, string message = "Operation Failed.")
        {
            ErrorCode = errorCode;
            IsSuccess = false;
            Message = message;
        }
    }
}
