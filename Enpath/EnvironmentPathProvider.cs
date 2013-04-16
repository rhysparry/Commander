namespace Enpath
{
    using System;

    public class EnvironmentPathProvider : IPathProvider
    {
        private readonly EnvironmentVariableTarget _target;

        public EnvironmentPathProvider(EnvironmentVariableTarget target)
        {
            _target = target;
        }

        public string Path
        {
            get { return Environment.GetEnvironmentVariable("PATH", _target); }
            set { Environment.SetEnvironmentVariable("PATH", value, _target); }
        }
    }
}