using System;

namespace Mvvm.Core.Bases
{
    public static class Logger
    {
        public static Action<string> Log;
        public static Action<string> VMLog;
    }
}