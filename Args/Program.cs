namespace Args
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.Out.WriteLine(arg);
            }
        }
    }
}
