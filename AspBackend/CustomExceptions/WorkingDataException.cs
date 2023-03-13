namespace AspBackend.CustomExceptions ;

    public class WorkingDataException : Exception
    {
        public WorkingDataException(string message) : base(message)
        {
        }
    }