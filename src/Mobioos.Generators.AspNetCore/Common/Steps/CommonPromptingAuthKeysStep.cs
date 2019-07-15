using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using Mobioos.Scaffold.BaseInfrastructure.Contexts;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Mobioos.Generators.AspNetCore.Common.Steps
{
    [PromptingStep]
    public class CommonPromptingAuthKeysStep : StepBodyAsync
    {
        private readonly ISessionContext _context;
        private readonly IPrompting _promptingService;

        public CommonPromptingAuthKeysStep(ISessionContext context, IPrompting promptingService)
        {
            _context = context;
            _promptingService = promptingService;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var prompts = new Queue<Question>();
            var authProviders = ((IDictionary<string, object>)_context.DynamicContext).ContainsKey("AuthProviders") ? _context.DynamicContext.AuthProviders as List<Answer> : new List<Answer>();
            if (authProviders.Count() > 0)
                AddPrompt(prompts, authProviders);

            await _promptingService.Prompts(nameof(CommonPromptingAuthKeysStep), prompts, "Retrieving informations for selected authentication providers");

            return ExecutionResult.Next();
        }

        private static void AddPrompt(Queue<Question> prompts, List<Answer> authProviders)
        {
            var providers = AuthenticationProviders.AuthenticationProviderPrompts;
            if (authProviders != null)
            {
                foreach (var authProvider in authProviders)
                {
                    prompts.Enqueue(new Question
                    {
                        Name = providers[authProvider.Value].ClientName,
                        Message = providers[authProvider.Value].ClientMessage,
                        Type = QuestionType.Text
                    });

                    prompts.Enqueue(new Question
                    {
                        Name = providers[authProvider.Value].SecretName,
                        Message = providers[authProvider.Value].SecretMessage,
                        Type = QuestionType.Text
                    });
                }
            }
        }
    }
}
