namespace Wio.Booking.Business.Models.Validations.Document;

public class CnpjValidation
{
    public const int CnpjSize = 14;

    public static bool Validation(string cpnj)
    {
        var cnpjNumber = Utils.OnlyNumbers(cpnj);

        if (!HasValidSize(cnpjNumber)) return false;
        return !HaveRepeatedDigits(cnpjNumber) && HaveValidDigits(cnpjNumber);
    }

    private static bool HasValidSize(string valor) => valor.Length == CnpjSize;

    private static bool HaveRepeatedDigits(string valor)
    {
        string[] invalidNumbers =
        {
                "00000000000000",
                "11111111111111",
                "22222222222222",
                "33333333333333",
                "44444444444444",
                "55555555555555",
                "66666666666666",
                "77777777777777",
                "88888888888888",
                "99999999999999"
            };
        return invalidNumbers.Contains(valor);
    }

    private static bool HaveValidDigits(string valor)
    {
        var number = valor.Substring(0, CnpjSize - 2);

        var VerifyingDigit = new VerifyingDigit(number)
            .WithMultipliersFromTo(2, 9)
            .Replacing("0", 10, 11);

        var firstDigit = VerifyingDigit.CalculateDigit();
        VerifyingDigit.AddDigit(firstDigit);
        var secondDigit = VerifyingDigit.CalculateDigit();

        return string.Concat(firstDigit, secondDigit) == valor.Substring(CnpjSize - 2, 2);
    }
}

public class VerifyingDigit
{
    private string _number;
    private const int Module = 11;
    private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
    private readonly IDictionary<int, string> _substitutions = new Dictionary<int, string>();
    private bool _complementaryDoModule = true;

    public VerifyingDigit(string numero) => _number = numero;

    public VerifyingDigit WithMultipliersFromTo(int primeiroMultiplicador, int ultimoMultiplicador)
    {
        _multipliers.Clear();
        for (var i = primeiroMultiplicador; i <= ultimoMultiplicador; i++)
            _multipliers.Add(i);
        return this;
    }

    public VerifyingDigit Replacing(string substituto, params int[] digitos)
    {
        foreach (var i in digitos)
        {
            _substitutions[i] = substituto;
        }
        return this;
    }

    public void AddDigit(string digito)
    {
        _number = string.Concat(_number, digito);
    }

    public string CalculateDigit() => !(_number.Length > 0) ? "" : GetDigitSum();

    private string GetDigitSum()
    {
        var sum = 0;
        for (int i = _number.Length - 1, m = 0; i >= 0; i--)
        {
            var product = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
            sum += product;

            if (++m >= _multipliers.Count) m = 0;
        }

        var mod = (sum % Module);
        var result = _complementaryDoModule ? Module - mod : mod;

        return _substitutions.ContainsKey(result) ? _substitutions[result] : result.ToString();
    }
}

public class Utils
{
    public static string OnlyNumbers(string valor)
    {
        var onlyNumber = "";
        foreach (var s in valor)
        {
            if (char.IsDigit(s))
            {
                onlyNumber += s;
            }
        }
        return onlyNumber.Trim();
    }
}