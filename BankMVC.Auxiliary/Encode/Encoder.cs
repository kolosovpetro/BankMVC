using System.Linq;
using System.Text;

namespace BankMVC.Auxiliary.Encode
{
    public class Encoder
    {
        private const string Alphabet = "ABCDEFGHIJ";
        private readonly StringBuilder _builder = new StringBuilder();
        

        // VERIFY INPUT HERE AFTER ALL !!!
        public string Encode(int input)
        {
            var toString = input.ToString();
            _builder.Clear();

            foreach (var digit in toString) 
                _builder.Append(Alphabet.ElementAt(int.Parse(digit.ToString())));

            return _builder.ToString();
        }
    }
}