using Mobioos.Scaffold.Infrastructure.Logging;

namespace Mobioos.Generators.AspNetCore.Tests
{
    public class FakeLoggerProvider : IScaffoldLoggerProvider
    {
        public IScaffoldLogger GetLogger(string categoryName)
        {
            return new FakeLogger();
        }

        public IScaffoldLogger GetLogger(string name, string output)
        {
            return new FakeLogger();
        }
    }
}
