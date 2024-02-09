var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Skriv in ditt ord eller namn, använd inte å, ä eller ö.");

app.MapGet("/encrypt", (string text, int shift) => Encrypt(text, shift));

app.MapGet("/decrypt", (string text, int shift) => Decrypt(text, shift));

app.Run();


string Encrypt(string text, int shift)
    {
        string result = "";

        foreach (char ch in text)
        {
            if (!char.IsLetter(ch))
            {
                result += ch;
                continue;
            }

            char offset = char.IsUpper(ch) ? 'A' : 'a';
            char encrypted = (char)((((ch + shift) - offset) % 26) + offset);
            result += encrypted;
        }

        return result;
    }

    string Decrypt(string text, int shift)
    {
        return Encrypt(text, 26 - shift);
    }