using System.Text.RegularExpressions;

namespace PasswordKata;

public class ValidatePassword
{
    public static ValidationPasswordResult Validate(string pass)
    {
        var result = new ValidationPasswordResult {
            Result = true,
            Errors = ""
        };

        result = Validation(pass, @".{8,}", "Password must be at least 8 characters", result);
        result = Validation(pass, @"(\d+)\D+(\d+)|\d{2,}", "The password must contain at least 2 numbers", result); 
        result = Validation(pass, @"[A-Z]{1,}", "Password must contain at least one capital letter", result);
        result = Validation(pass, @"[^a-zA-Z0-9]", "Password must contain at least one special character", result);

        return result;
    }

    private static ValidationPasswordResult Validation(string pass, string pattern, string errorMessage,
        ValidationPasswordResult result)
    {
        var regex = new Regex(pattern);
        if (!regex.IsMatch(pass)) {
            if (!result.Result) {
                result.Errors += "\n" + errorMessage;
            }
            else {
                result.Errors = errorMessage;
            }
            result.Result = false;
        }

        return result;
    }
}