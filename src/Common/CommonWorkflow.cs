using Mobioos.Generators.AspNetCore.Common.Steps;
using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace Mobioos.Generators.AspNetCore
{
    [WorkFlow(Id = "AspNetCoreCommonWorkflow", Order = 1)]
    public class CommonWorkflow : IWorkflow
    {
        public string Id => "AspNetCoreCommonWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder builder)
        {
            builder.StartWith<CommonPromptingAuthProvidersStep>()
                   .WaitForAnswers(nameof(CommonPromptingAuthProvidersStep))
                   .Then<CommonPromptingAuthKeysStep>()
                   .WaitForAnswers(nameof(CommonPromptingAuthKeysStep))
                   .Then<CommonWritingStep>()
                   .Then<WorkFlowEndStepBase>();
        }
    }
}
