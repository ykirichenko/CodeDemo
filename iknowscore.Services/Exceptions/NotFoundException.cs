namespace iknowscore.Services.Exceptions
{
    /// <summary>
    /// NotFound
    /// </summary>
    public class NotFoundException : IKnowScoreException
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
