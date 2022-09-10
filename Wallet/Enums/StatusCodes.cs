namespace Wallet.Enums
{
    public enum StatusCodes
    {
        Success = 200,
        Error = 500,
        EntityNotFound = 400,
        UserNotFound = 404,
        InsufficientFunds = 406,
        ReplenishYourself = 407,
        NegativeBalance = 409
    }
}