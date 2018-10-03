namespace iknowscore.Services.Exceptions
{
    /// <summary>
    /// ValidationException
    /// </summary>
    public class ValidationException : IKnowScoreException
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}
