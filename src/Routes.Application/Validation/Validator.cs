using System;
using System.Collections.Generic;
using System.Text;
using Routes.Core.Entities;

namespace Routes.Application.Validation
{
    public class Validator
    {
        public static void Validate(string origin, string destination)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(origin) && string.IsNullOrEmpty(destination))
            {
                message = "The 'origin' and 'destination' parameters are required and must not be empty.";
            }
            else if (string.IsNullOrEmpty(origin))
            {
                message = "The 'origin' parameter is required and must not be empty.";
            }
            else if (string.IsNullOrEmpty(destination))
            {
                message = "The 'destination' parameter is required and must not be empty.";
            }

            if (!string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void Validate(Airport origin, Airport destination)
        {
            string message = string.Empty;

            if (origin == null && destination == null)
            {
                message = "No Airports were found with the informed 'origin' and 'destination' values.";
            }
            else if (origin == null)
            {
                message = "No Airport was found with the informed 'origin' value.";
            }
            else if (destination == null)
            {
                message = "No Airport was found with the informed 'destination' value.";
            }

            if (!string.IsNullOrEmpty(message))
            {
                throw new KeyNotFoundException(message);
            }
        }
    }
}
