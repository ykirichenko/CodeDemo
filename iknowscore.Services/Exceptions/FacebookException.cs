namespace iknowscore.Services.Exceptions
{
    /// <summary>
    /// FacebookException
    /// </summary>
    public class FacebookException : IKnowScoreException
    {
        public FacebookException(string message)
            : base(message)
        {
        }
    }
}
