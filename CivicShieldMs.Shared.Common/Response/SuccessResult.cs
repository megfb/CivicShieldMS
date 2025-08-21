namespace CivicShieldMS.Shared.Common.Response
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {

        }

        public SuccessResult(string message) : base(true, message)
        {

        }
    }

}
