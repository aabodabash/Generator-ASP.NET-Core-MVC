using Mobioos.Foundation.Jade.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Mobioos.Generators.AspNetCore.Tests
{
    public class SecurityGeneratorTests : BaseGeneratorTests, IDisposable
    {
        [Fact]
        public void Roles_Template_Test()
        {
            var template = new RolesTemplate(new SmartAppInfo() { Id = ApplicationId }, new List<string> { "Admin", "Editor", "Reader" });
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend.Security", output);
        }

        [Fact]
        public void Roles_Template_NullParameter_Test()
        {
            var template = new RolesTemplate(null, null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        [Fact]
        public void StartupAuth_Template_Test()
        {
            var template = new StartupAuth(new SmartAppInfo() { Id = ApplicationId }, new Dictionary<string,string>());
            var output = template.TransformText();
            Assert.NotNull(output);
            Assert.NotEmpty(output);
            Assert.Contains($"namespace {ApplicationId}.Backend", output);
        }

        [Fact]
        public void StartupAuth_Template_NullParameter_Test()
        {
            var template = new StartupAuth(null, null);
            Assert.Throws<NullReferenceException>(() => template.TransformText());
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
