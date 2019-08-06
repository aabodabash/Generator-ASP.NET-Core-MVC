using Mobioos.Generators.AspNetCore.Api.Steps;
using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace Mobioos.Generators.AspNetCore
{
    [Workflow(
        Id = "AspNetCoreApiWorkflow",
        Order = 3)]
    public class ApiWorkflow : IWorkflow
    {
        public string Id => "AspNetCoreApiWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        => builder.StartWith<ApiWritingStep>()
                  .Then<WorkflowEndStepBase>();
    }
}
