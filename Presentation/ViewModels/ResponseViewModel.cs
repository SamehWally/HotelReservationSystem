using Domain.Enums;

namespace Presentation.ViewModels
{
    public class ResponseViewModel<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool IsSuccess { get; set; }
        public ErrorCode ErrorCode { get; set; }
    }
}
