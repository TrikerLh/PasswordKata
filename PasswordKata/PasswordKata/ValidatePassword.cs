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

        if (pass.Length < 8)
        {
            result.Result = false;
            result.Errors = "Password must be at least 8 characters";
        }

        var regex = new Regex(@"^(?=(?:\D*\d){2})[a-zA-Z0-9]*$");
        if (!regex.IsMatch(pass))
        {
            if (!result.Result)
            {
                result.Errors += "\nThe password must contain at least 2 numbers";
            }
            else 
            {
                result.Errors = "The password must contain at least 2 numbers";
            }
            result.Result = false;
        }

        return result;
    }
}