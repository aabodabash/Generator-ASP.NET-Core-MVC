using Mobioos.Scaffold.Infrastructure.Logging;
using System;

namespace Mobioos.Generators.AspNetCore.Tests
{
    public class FakeLogger : IScaffoldLogger
    {
        public bool IsDebugEnabled
        {
            get
            {
                return true;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return true;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return true;
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return true;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return true;
            }
        }

        public void Debug(Exception exception)
        {
        }

        public void Debug(string message)
        {
        }

        public void Debug(string format, params object[] args)
        {
        }

        public void Debug(string message, Exception ex)
        {
        }

        public void Error(Exception exception)
        {
        }

        public void Error(string message)
        {
        }

        public void Error(string format, params object[] args)
        {
        }

        public void Error(string message, Exception ex)
        {
        }

        public void Fatal(Exception exception)
        {
        }

        public void Fatal(string message)
        {
        }

        public void Fatal(string format, params object[] args)
        {
        }

        public void Fatal(string message, Exception ex)
        {
        }

        public void Info(Exception exception)
        {
        }

        public void Info(string message)
        {
        }

        public void Info(string format, params object[] args)
        {
        }

        public void Info(string message, Exception ex)
        {
        }

        public void Warn(Exception exception)
        {
        }

        public void Warn(string message)
        {
        }

        public void Warn(string format, params object[] args)
        {
        }

        public void Warn(string message, Exception ex)
        {
        }
    }
}
