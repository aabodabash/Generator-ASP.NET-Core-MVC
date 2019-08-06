using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Mobioos.Generators.AspNetCore
{
    [PromptingStep]
    public class CommonPromptingAuthProvidersStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IPrompting _promptingService;

        public CommonPromptingAuthProvidersStep(
            ISessionContext context,
            IPrompting promptingService)
        {
            _context = context;
            _promptingService = promptingService;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var prompts = new Queue<Question>();

            var dynamicContext = (IDictionary<string, object>)_context.DynamicContext;

            var authChoice = dynamicContext.ContainsKey("AuthOrNot") ?
                _context.DynamicContext.AuthOrNot as List<Answer> :
                new List<Answer>();

            string choice = (authChoice != null && authChoice.Count > 0) ?
                authChoice.FirstOrDefault().Value :
                "no";

            if (choice == "yes")
            {
                var authProviderChoices = new List<Choice>
                {
                    new Choice
                    {
                        Key = "googleAuth",
                        Value = "googleAuth",
                        Name = "Google OAUTH2"
                    },
                    new Choice
                    {
                        Key = "microsoftAuth",
                        Value = "microsoftAuth",
                        Name = "Microsoft"
                    },
                    new Choice
                    {
                        Key = "facebookAuth",
                        Value = "facebookAuth",
                        Name = "Facebook"
                    },
                    new Choice
                    {
                        Key = "twitterAuth",
                        Value = "twitterAuth",
                        Name = "Twitter"
                    }
                };

                prompts.Enqueue(new ChoiceQuestion()
                {
                    Name = "AuthProviders",
                    Message = "Choose additional authentication providers",
                    Type = QuestionType.Select,
                    Choices = authProviderChoices
                });
            }

            await _promptingService.Prompts(
                nameof(CommonPromptingAuthProvidersStep),
                prompts,
                "Select your authentication providers");

            return ExecutionResult.Next();
        }
    }
}
