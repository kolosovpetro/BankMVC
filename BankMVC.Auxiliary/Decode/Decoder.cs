using System.Text;

namespace BankMVC.Auxiliary.Decode
{
    public class Decoder
    {
        private const string Alphabet = "ABCDEFGHIJ";
        private readonly StringBuilder _builder = new StringBuilder();

        public int Decode(string input)
        {
            _builder.Clear();
            foreach (var letter in input) 
                _builder.Append(Alphabet.IndexOf(letter));

            return int.Parse(_builder.ToString());
        }
    }
}