namespace Monitoring.Service.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        /// <summary>
        ///
        /// </summary>
        T Data { get; }

        /// <summary>
        ///
        /// </summary>
        int Size { get; }
    }
}