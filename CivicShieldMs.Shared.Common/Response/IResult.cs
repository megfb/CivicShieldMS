namespace CivicShieldMS.Shared.Common.Response
{
    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        int? StatusCodes { get; set; }

    }
}
