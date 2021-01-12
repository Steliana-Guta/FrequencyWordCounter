using System;

namespace RedGate
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleCharacterReader words = new SimpleCharacterReader();
            WordFrequency book = new WordFrequency(words);
            Console.ReadKey();
        }
    }
}
