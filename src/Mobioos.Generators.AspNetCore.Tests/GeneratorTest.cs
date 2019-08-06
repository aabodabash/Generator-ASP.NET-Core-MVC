using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Generators.AspNetCore.Api.Steps;
using Mobioos.Generators.AspNetCore.Data.Steps;
using Mobioos.Generators.AspNetCore.Security.Steps;
using Mobioos.Scaffold.BaseGenerators.Testing;
using System;
using System.Collections.Generic;
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
                    new List<Answer>
                    {
                        new Answer
                        {
                            Name = "yes",
                            Type = AnswerType.Choice,
                            Value = "yes"
                        }
                    })
                .AddAnswer(
                    "AuthProviders",
                    new List<Answer>
                    {
                        new Answer
                        {
                            Name = "googleAuth",
                            Type = AnswerType.Select,
                            Value = "googleAuth"
                        },
                        new Answer
                        {
                            Name = "microsoftAuth",
                            Type = AnswerType.Select,
                            Value = "microsoftAuth"
                        },
                        new Answer
                        {
                            Name = "facebookAuth",
                            Type = AnswerType.Select,
                            Value = "facebookAuth"
                        }
                    })
                .AddAnswer(
                    "GoogleAuthClientId",
                    new List<Answer>
                    {
                        new Answer
                        {
                            Name = "GoogleAuthClientId",
                            Type = AnswerType.Text,
                            Value = "22"
                        }
                    })
                .AddAnswer(
                    "GoogleAuthSecret",
                    new List<Answer>
                    {
                        new Answer
                        {
                            Name = "GoogleAuthSecret",
                            Type = AnswerType.Text,
                            Value = "22"
                        }
                    })
                .AddAnswer(
                    "MicrosoftAuthClientId",
                    new List<Answer>
                    {
                        new Answer
                        {
                            Name = "MicrosoftAuthClientId",
                            Type = AnswerType.Text,
                            Value = "22"
                        }
                    })
                .AddAnswer(
                    "MicrosoftAuthSecret",
                    new List<Answer>
                    {
                        new Answer
                        {
                            Name = "MicrosoftAuthSecret",
                            Type = AnswerType.Text,
                            Value = "22"
                        }
                    })
                .AddAnswer(
                    "FacebookAuthConsumerKey",
                    new List<Answer>
                    {
                        new Answer
                        {
                            Name = "FacebookAuthConsumerKey",
                            Type = AnswerType.Text,
                            Value = "22"
                        }
                    })
                .AddAnswer(
                    "FacebookAuthConsumerSecret",
                    new List<Answer>
                    {
                        new Answer
                        {
                            Name = "FacebookAuthConsumerSecret",
                            Type = AnswerType.Text,
                            Value = "22"
                        }
                    })
                .RegisterStep<CommonWritingStep>()
                .RegisterStep<CommonPromptingAuthStep>()
                .RegisterStep<CommonPromptingAuthProvidersStep>()
                .RegisterStep<CommonPromptingAuthKeysStep>()
                .RegisterStep<ApiWritingStep>()
                .RegisterStep<DataWritingStep>()
                .RegisterStep<SecurityWritingStep>()
                .Build();

            generatorTest.RegisterWorkflow<CommonWorkflow>("AspNetCoreCommonWorkflow");
            generatorTest.RegisterWorkflow<DataWorkflow>("AspNetCoreDataWorkflow");
            generatorTest.RegisterWorkflow<ApiWorkflow>("AspNetCoreApiWorkflow");
            generatorTest.RegisterWorkflow<SecurityWorkflow>("AspNetCoreSecurityWorkflow");

            await generatorTest.Start();
        }
    }
}
