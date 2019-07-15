using Mobioos.Generators.AspNetCore.Common.Steps;
using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace Mobioos.Generators.AspNetCore
{
    [Workflow(Id = "AspNetCoreCommonWorkflow", Order = 1)]
    public class CommonWorkflow : IWorkflow
    {
        public string Id => "AspNetCoreCommonWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        => builder.StartWith<CommonPromptingAuthStep>()
                  .WaitFor(
                      nameof(CommonPromptingAuthStep),
                      data => nameof(CommonPromptingAuthStep))
                  .Then<CommonPromptingAuthProvidersStep>()
                  .WaitFor(
                      nameof(CommonPromptingAuthProvidersStep),
                      data => nameof(CommonPromptingAuthProvidersStep))
                  .Then<CommonPromptingAuthKeysStep>()
                  .WaitFor(
                      nameof(CommonPromptingAuthKeysStep),
                      data => nameof(CommonPromptingAuthKeysStep))
                  .Then<CommonWritingStep>()
                  .Then<WorkflowEndStepBase>();
    }
}
