﻿using System;

namespace Marketplace.Domain.Exceptions
{
    public class InvalidEntityStateException : Exception
    {
        public InvalidEntityStateException(object entity, string message) : base($"Entity  {entity.GetType().Name} state change reject , {message}")
        {

        }
    }
}
