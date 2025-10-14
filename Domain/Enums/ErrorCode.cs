namespace Domain.Enums
{
    public enum ErrorCode
    {
        NoError = 0,

        RoomNotFound = 100,
        InvalidRoomId = 101,

        NoRoomsAvailableBetweenThisDate=102,
        OfferNotFound=100,
        
        //Reservations
        UpdatedFailed = 199,
        ReservationNotFound = 200,
        AddedFailed = 201,

        FeedbackFailed = 300,
        ReplyFailed = 301,

        ValidationFailed = 2,
        Unauthorized = 3,
        Forbidden = 4,
        Conflict = 5,
        InternalError = 6,
        DuplicateEntry = 7,
        InvalidInput = 8,

        NotFound = 103,

        CancelFailed = 101,
        ConfirmFailed = 102,

        InvalidCredentials = 300,
        FaildRoleAssignment = 301,

        FaildResponseDto=400,
        OperationFailed = 401,
        Duplicate = 402
    }
}
