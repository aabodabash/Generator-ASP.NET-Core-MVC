using Mobioos.Foundation.Prompt;
using Mobioos.Foundation.Prompt.Infrastructure;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using Mobioos.Scaffold.BaseInfrastructure.Services.GeneratorsServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace Mobioos.Generators.AspNetCore
{
    [PromptingStep]
    public class CommonPromptingAuthStep : StepBodyAsync
    {
        private readonly IPrompting _promptingService;

        public CommonPromptingAuthStep(IPrompting promptingService)
        {
            _promptingService = promptingService;
        }

        public async override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            var prompts = new Queue<Question>();

            var authChoices = new List<Choice>
            {
                new Choice
                {
                    Key = "yes",
                    Value = "yes",
                    Name = "Yes"
                },
                new Choice
                {
                    Key = "no",
                    Value = "no",
                    Name = "No"
                }
            };

            prompts.Enqueue(new ChoiceQuestion()
            {
                Name = "AuthOrNot",
                Message = "Do you want to add external authentication features ?",
                Type = QuestionType.Choice,
                Choices = authChoices
            });

            await _promptingService.Prompts(
                nameof(CommonPromptingAuthStep),
                prompts,
                "Retrieving your choice on external authentication");

            return ExecutionResult.Next();
        }
    }
}
