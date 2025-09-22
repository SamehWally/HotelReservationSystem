using Domain.Enums;
using EnumContainer = Domain.Enums;

namespace Presentation.ViewModels.Response
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
