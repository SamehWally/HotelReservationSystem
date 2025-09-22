namespace Domain.Enums
{
    public enum ErrorCode
    {
        NoError = 0,

        RoomNotFound = 100,
        InvalidRoomId = 101,
        NoRoomsAvailableBetweenThisDate=102,

        ValidationFailed = 2,
        Unauthorized = 3,
        Forbidden = 4,
        Conflict = 5,
        InternalError = 6,
        DuplicateEntry = 7,
        InvalidInput = 8,
    }
}
