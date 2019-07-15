using Mobioos.Generators.AspNetCore.Api.Steps;
using Mobioos.Generators.AspNetCore.Common.Steps;
using Mobioos.Generators.AspNetCore.Data.Steps;
using Mobioos.Generators.AspNetCore.Security.Steps;
using Mobioos.Scaffold.BaseGenerators.Testing;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Mobioos.Generators.AspNetCore.Tests
{
    public class GeneratorTest
    {
        [Fact]
        public async Task Test()
        {
            var generatorTest = new GeneratorTestBuilder()
                .InitializeContext(
                    Path.GetDirectoryName(
                        Assembly
                            .GetExecutingAssembly()
                            .Location),
                    Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "Manifest"),
                    Path.Combine(
                        Path.GetDirectoryName(
                            Assembly
                                .GetExecutingAssembly()
                                .Location),
                        "Result"),
                    "AspNetCore")
                .AddAnswer(
                    "AuthOrNot",
                    "no")
                .RegisterStep<CommonWritingStep>()
                .RegisterStep<CommonPromptingAuthStep>()
                .RegisterStep<CommonPromptingAuthProvidersStep>()
                .RegisterStep<CommonPromptingAuthKeysStep>()
                .RegisterStep<ApiWritingStep>()
                .RegisterStep<DataWritingStep>()
                .RegisterStep<SecurityWritingStep>()
                .Build();

            generatorTest.RegisterWorflow<CommonWorkflow>("AspNetCoreCommonWorkflow");
            generatorTest.RegisterWorflow<DataWorkflow>("AspNetCoreDataWorkflow");
            generatorTest.RegisterWorflow<ApiWorkflow>("AspNetCoreApiWorkflow");
            generatorTest.RegisterWorflow<SecurityWorkflow>("AspNetCoreSecurityWorkflow");

            await generatorTest.Start();
        }
    }
}
