using Monitoring.Service.Utilities.Results.Helpers;

namespace Monitoring.Service.Utilities.Results.Abstract
{
    public interface IResult
    {
        ResultStatus Status { get; }

        string Message { get; }
    }
}