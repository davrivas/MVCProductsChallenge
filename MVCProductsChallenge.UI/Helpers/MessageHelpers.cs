using MVCProductsChallenge.Model.Models;
using System;

namespace MVCProductsChallenge.UI.Helpers
{
    public static class MessageHelpers
    {
        public static Message GetSuccessMessage(string body)
        {
            return new Message
            {
                Title = "Success",
                Body = body
            };
        }

        public static Message GetErrorMessage(string body)
        {
            return new Message
            {
                Title = "Error",
                Body = body
            };
        }

        public static Message GetExceptionMessage(Exception ex)
        {
            return new Message
            {
                Title = "Error",
                Body = ex.Message
            };
        }
    }
}