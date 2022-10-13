using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diamond_Kata
{
    public class Diamond
    {
        public readonly char _letter;
        public char Separator { get; set; } = ' ';
        private const char separator = ' ';
        private const char LetterA = 'A';
        private List<string> _lines = new();
        private const string ALPHABET = "ABCDEFGHIZKLMNOPQRSTUVWXYZ";

        public IReadOnlyCollection<string> Lines => _lines;

        public Diamond(char letter)
        {
            Validate(letter);
            _letter = char.ToUpperInvariant(letter);
            GenerateDiamond();
        }

        private void GenerateDiamond()
        {
            if (_letter == LetterA)
            {
                _lines.Add("A");
                return;
            }

            var diamondSize = (ALPHABET.IndexOf(_letter) + 1) * 2 - 1;
            var pad = string.Empty.PadLeft(diamondSize / 2, separator);

            var firstAndLastLine = $"{pad}A{pad}";

            var upperHalf = Enumerable.Range(1, diamondSize / 2).Select(lineNo =>
            {
                var midsectionSize = diamondSize / 2;
                var currentLetter = ALPHABET[lineNo];
                var externalPad = string.Empty.PadLeft(midsectionSize - lineNo, separator);
                var internalPad = string.Empty.PadLeft(lineNo * 2 - 1, separator);

                var line = $"{externalPad}{currentLetter}{internalPad}{currentLetter}{externalPad}";
                return line;
            });

            var lowerHalf = upperHalf.Reverse().Skip(1);

            _lines.Add(firstAndLastLine);
            _lines.AddRange(upperHalf);
            _lines.AddRange(lowerHalf);
            _lines.Add(firstAndLastLine);

        }

        private static void Validate(char letter)
        {
            if (!IsEnglishLetter(letter)) throw new ArgumentException($"Input {{ {letter} }} is not a english alphabet letter [a-z][A-Z]");
        }

        private static bool IsEnglishLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        public void Display()
        {
            _lines
                .Select(line => line.Replace(separator, Separator))
                .ToList().ForEach(Console.WriteLine);
        }
    }
}
