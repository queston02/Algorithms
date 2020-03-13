using System;

namespace Algorithms
{
    class Fibonacci
    {
        private static int _last = 0;
        private static int _current = 1;
        static void Main(string[] args)
        {
            Console.WriteLine(Next());
            Console.WriteLine(Next());
            Console.WriteLine(Next());
            Console.WriteLine(Next());
            Console.WriteLine(Next());
            Console.WriteLine(Next());
        }

        private static int Next()
        {
            var fibNum = _current;
            var tempLast = fibNum;
            _current = _current + _last;
            _last = tempLast;
            return fibNum;
        }
    }
}
