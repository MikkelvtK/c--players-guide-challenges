
while (true)
{
    Console.Write("Test your passwords (quit to stop): ");
    string? answer = Console.ReadLine();

    if (answer == null) continue;
    if (answer == "quit") break;

    bool isValid = PasswordValidator.ValidatePassword(answer);
    if (isValid)
        Console.WriteLine("This password works!");
    else
        Console.WriteLine("This password is not good enough.");
}

class PasswordValidator
{
    public static bool ValidatePassword(string password)
    {
        if (password.Length < 6 || password.Length > 13) return false;

        bool hasUpper = false;
        bool hasLower = false;
        bool hasNumber = false;

        foreach(char c in password)
        {
            if (c == 'T') return false;
            if (c == '&') return false;

            if (char.IsUpper(c) && !hasUpper) hasUpper = true;
            if (char.IsLower(c) && !hasLower) hasLower = true;
            if (char.IsDigit(c) && !hasNumber) hasNumber = true;
        }

        if (hasUpper && hasLower && hasNumber) return true;
        return false;
    }
}
