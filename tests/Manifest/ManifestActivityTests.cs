using Mobioos.Scaffold.Generators.Builder;
using Mobioos.Scaffold.Core.Runtime;
using System.Dynamic;
using Xunit;
using System.IO;
using Mobioos.Scaffold.Infrastructure.Runtime;
using System.Threading.Tasks;
using Mobioos.Generators.AspNetCore.Tests;

namespace Mobioos.Scaffold.CoreTests.Manifest
{
    public class ManifestActivityTests
    {
        [Fact]
        public async Task StartupCreationTest()
        {
            Moq.Mock<IRuntimeEngine> runtimeEngine = new Moq.Mock<IRuntimeEngine>();
            runtimeEngine.Setup(x => x.Logger).Returns(new FakeLogger());

            ManifestActivity activity = new ManifestActivity("ManifestTest");
            ActivityContext context = new ActivityContext(new ExpandoObject(), new ActivityContext(null,null,null), new RuntimeContext(null, runtimeEngine.Object, null));
            context.DynamicContext.ManifestDir = Path.Combine(Directory.GetCurrentDirectory(),"Manifest", "ManifestSource");
            await activity.Initializing(context);

            Assert.NotNull(activity.Context.DynamicContext.Manifest);
        }
    }
}
