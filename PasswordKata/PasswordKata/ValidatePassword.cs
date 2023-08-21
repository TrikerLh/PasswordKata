namespace PasswordKata;

public class ValidatePassword
{
    public static ValidationPasswordResult Validate(string pass)
    {
        var result = new ValidationPasswordResult {
            Result = false,
            Errors = "Password must be at least 8 characters"
        };
        return result;
    }
}