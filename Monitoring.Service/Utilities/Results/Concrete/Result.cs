using Monitoring.Service.Utilities.Results.Abstract;
using Monitoring.Service.Utilities.Results.Helpers;

namespace Monitoring.Service.Utilities.Results.Concrete
{
    /// <summary>
    ///
    /// </summary>
    public class Result : IResult
    {
        /// <summary>
        ///
        /// </summary>
        public ResultStatus Status { get; }

        /// <summary>
        ///
        /// </summary>
        public string Message { get; }

        /// <summary>
        ///
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="status"></param>
        public Result(ResultStatus status)
        {
            Status = status;
        }

        /// <summary>
        ///
        /// </summary>
        public Result(ResultStatus status, string message) : this(status)
        {
            Message = message;
        }
    }
}