using EnumContainer = Domain.Enums;

namespace Presentation.ViewModels.Response
{
    public class SuccessResponseViewModel<T> : ResponseViewModel<T>
    {
        public SuccessResponseViewModel(T data, string message = "Operation Completed successfully.") 
        {
            Data = data;
            ErrorCode = EnumContainer.ErrorCode.NoError;
            IsSuccess = true;
            Message = message;
        }
    }
}
