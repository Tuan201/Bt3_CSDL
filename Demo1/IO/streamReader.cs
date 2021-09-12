using System;

namespace Demo1.IO
{
    internal class streamReader : IDisposable
    {
        public bool EndOfStream { get; internal set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}