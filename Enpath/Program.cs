namespace Enpath
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                AddCurrentPath();
            }
            else
            {
                Console.Error.WriteLine("Arguments not currently supported.");
            }
        }

        private static void AddCurrentPath()
        {
            var provider = new EnvironmentPathProvider(EnvironmentVariableTarget.User);
            AddPath(provider, Environment.CurrentDirectory);
        }

        private static void AddPath(IPathProvider provider, string path)
        {
            var currentPaths =
                provider.Path.ToLowerInvariant()
                        .Split(Path.PathSeparator)
                        .Select(p => p.TrimEnd(Path.DirectorySeparatorChar));

            var invariantPath = path.ToLowerInvariant().TrimEnd(Path.DirectorySeparatorChar);
            if (currentPaths.Any(p => p.Equals(invariantPath)))
            {
                return;
            }

            provider.Path += Path.PathSeparator + path;
        }
    }
}
