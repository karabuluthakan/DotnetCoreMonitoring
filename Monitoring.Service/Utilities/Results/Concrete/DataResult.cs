using System.Collections.Generic;
using Monitoring.Service.Utilities.Results.Abstract;
using Monitoring.Service.Utilities.Results.Helpers;

namespace Monitoring.Service.Utilities.Results.Concrete
{
    /// <summary>
    ///
    /// </summary>
    public class DataResult<T> : Result, IDataResult<T> where T : class
    {
        /// <summary>
        ///
        /// </summary>
        public T Data { get; }

        /// <summary>
        ///
        /// </summary>
        public int Size { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="status"></param>
        public DataResult(ResultStatus status) : base(status)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        public DataResult(ResultStatus status, string message) : base(status, message)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <param name="status"></param>
        /// <param name="message"></param>
        public DataResult(T data, ResultStatus status, string message) : base(status, message)
        {
            Data = data;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <param name="status"></param>
        public DataResult(T data, ResultStatus status) : base(status)
        {
            Data = data;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <param name="status"></param>
        /// <param name="size"></param>
        public DataResult(T data, ResultStatus status, int size) : base(status)
        {
            Data = data;
            Size = size;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="data"></param>
        /// <param name="status"></param>
        /// <param name="size"></param>
        /// <param name="message"></param>
        public DataResult(T data, ResultStatus status, int size, string message) : base(status, message)
        {
            Data = data;
            Size = size;
        }
    }
}