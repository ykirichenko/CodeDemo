using System;

namespace iknowscore.Services.Exceptions
{
    /// <summary>
    /// Base IKnowScoreException
    /// </summary>
    public class IKnowScoreException : Exception
    {
        protected IKnowScoreException(string message)
            : base(message)
        {
        }
    }
}
