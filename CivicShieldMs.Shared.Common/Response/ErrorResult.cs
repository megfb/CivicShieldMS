namespace CivicShieldMS.Shared.Common.Response
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {

        }

        public ErrorResult(string message, int? statusCodes = 200) : base(false, message, statusCodes)
        {

        }
    }
}
