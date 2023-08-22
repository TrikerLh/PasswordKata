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
        return result;
    }
}