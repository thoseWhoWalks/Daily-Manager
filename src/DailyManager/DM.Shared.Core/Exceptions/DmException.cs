namespace DM.Shared.Core.Exceptions
{
    public abstract class DmException : Exception
    {
        protected DmException(string message) : base(message)
        {

        }
    }
}
