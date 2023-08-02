namespace TravelPackage.Exceptions
{
    public class InclusionNotFoundException : Exception
    {
        public InclusionNotFoundException() : base()
        {
        }

        public InclusionNotFoundException(string message) : base(message)
        {
        }
    }
}
