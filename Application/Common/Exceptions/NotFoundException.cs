using System;

namespace OfferMakerForCggCQRS.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) was not found")
        {

        }
    }
}
