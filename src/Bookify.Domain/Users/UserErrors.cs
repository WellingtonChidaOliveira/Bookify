using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users
{
    public static class UserErrors
    {
        public static Error NotFound = new(
                       "User.NotFound",
                                  "The user with the specified identifier was not found");

        public static Error InvalidEmail = new(
                       "User.InvalidEmail",
                                  "The email is invalid");

        public static Error InvalidPassword = new(
                       "User.InvalidPassword",
                                  "The password is invalid");

        public static Error InvalidName = new(
                       "User.InvalidName",
                                  "The name is invalid");

        public static Error InvalidPhoneNumber = new(
                       "User.InvalidPhoneNumber",
                                  "The phone number is invalid");

        public static Error InvalidAddress = new(
                       "User.InvalidAddress",
                                  "The address is invalid");

        public static Error InvalidRole = new(
                       "User.InvalidRole",
                                  "The role is invalid");

        public static Error InvalidStatus = new(
                       "User.InvalidStatus",
                                  "The status is invalid");

        public static Error InvalidToken = new(
                       "User.InvalidToken",
                                  "The token is invalid");

        public static Error InvalidRefreshToken = new(
                       "User.InvalidRefreshToken",
                                  "The refresh token is invalid");

        public static Error InvalidPasswordResetToken = new(
                       "User.InvalidPasswordResetToken",
                                  "The password reset token is invalid");

        public static Error InvalidPasswordResetTokenExpiration = new(
                       "User.InvalidPasswordResetTokenExpiration",
                                  "The password reset token has expired");

        public static Error InvalidPasswordResetTokenUser = new(
                       "User.InvalidPasswordResetTokenUser",
                                  "The password reset token is not for the specified user");

        public static Error InvalidEmailConfirmationToken = new(
                       "User.InvalidEmailConfirmationToken",
                                  "The email confirmation token is invalid");

        public static Error InvalidEmailConfirmationTokenExpiration = new(
                       "User.InvalidEmailConfirmationTokenExpiration",
                                  "The email confirmation token has expired");

        public static Error InvalidEmailConfirmationTokenUser = new(
                       "User.InvalidEmailConfirmationTokenUser",
                                  "The email confirmation token is not for the specified user");

        public static Error InvalidRefreshTokenExpiration = new(
                       "User.InvalidRefreshTokenExpiration",
                                  "The refresh token has expired");

        public static Error InvalidRefreshTokenUser = new(
                       "User.InvalidRefreshTokenUser",
                                  "The refresh token is not for the specified user");

        public static Error InvalidPasswordResetTokenUserStatus = new(
                       "User.InvalidPasswordResetTokenUserStatus",
                                  "The password reset token is");
        public static Error InvalidCredentials = new(
            "User.InvalidCredentials",
            "The credentials are invalid");
    }
}
