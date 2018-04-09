using Mobioos.Scaffold.Core.Runtime;
using Mobioos.Scaffold.Infrastructure.Runtime;
using Mobioos.Foundation.Jade.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using Moq;
using Mobioos.Scaffold.Generators.Builder;

namespace Mobioos.Generators.AspNetCore.Tests
{
    public class BaseGeneratorTests
    {
        protected string ApplicationId = "MyApp";

        protected IActivityContext GetContext()
        {
            Mock<IRuntimeEngine> runtimeEngine = new Mock<IRuntimeEngine>();
            runtimeEngine.Setup(x => x.Logger).Returns(new FakeLogger());

            Mock<IRuntimeContext> runtimeContext = new Mock<IRuntimeContext>();
            runtimeContext.Setup(x => x.Runtime).Returns(runtimeEngine.Object);

            var context = new ActivityContext(new ExpandoObject(), null, runtimeContext.Object);
            context.DynamicContext.Manifest = new SmartAppInfo { Title = "TestApp", Id = "MyApp" };
            context.DynamicContext.SelectedRoles = new List<string>() { "Admin", "Editor", "Reader" };
            context.DynamicContext.GeneratorPath = Directory.GetParent(Directory.GetCurrentDirectory());

            var entity1 = new EntityInfo() { Id = "EntityBase"};
            entity1.Properties.Add(new PropertyInfo() { Id = "Id", Type = "int", IsKey = true });

            var properties = new List<PropertyInfo>();
            var references = new List<ReferenceInfo>();


            var entity2 = new EntityInfo() { Id = "Person", Extends = entity1.Id, BaseEntity = entity1 };

            entity2.Properties.Add(new PropertyInfo() { Id = "Id", Type = "int", IsKey = true });
            for (int i = 0; i < 5; i++)
            {
                entity2.Properties.Add(new PropertyInfo() { Id = $"PropertyInfo{i}", Type = "string", IsKey = false });
            }

            entity2.References.Add(new ReferenceInfo() { IsCollection = true, Id = "Parent", Type = entity2.Id, Reference = entity1 });

            context.DynamicContext.Manifest.DataModel = new DataModel();

            context.DynamicContext.Manifest.DataModel.Entities.Add(entity1);
            context.DynamicContext.Manifest.DataModel.Entities.Add(entity2);
            return context;
        }

        protected async Task<IActivityContext> GetTestContext()
        {
            Moq.Mock<IRuntimeEngine> runtimeEngine = new Moq.Mock<IRuntimeEngine>();

            ManifestActivity activity = new ManifestActivity("ManifestTest");
            ActivityContext context = new ActivityContext(new ExpandoObject(), new ActivityContext(null, null, null), new RuntimeContext(null, runtimeEngine.Object, null));
            context.DynamicContext.ManifestDir = Path.Combine(Directory.GetCurrentDirectory(), "Manifest", "ManifestSource");
            await activity.Initializing(context);

            return activity.Context;
        }

        protected void Clear()
        {
            var directoryPath = Path.Combine(Path.GetTempPath(), ApplicationId);
            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath, true);
        }
    }
}
