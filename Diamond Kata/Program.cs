using Diamond_Kata;

namespace Diamond_Kata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var diamond = new Diamond('D');
            diamond.Separator = '-';
            diamond.Display();
            Console.ReadLine();
        }
    }
}