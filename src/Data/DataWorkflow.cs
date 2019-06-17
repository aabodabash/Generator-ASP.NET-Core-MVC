using Mobioos.Generators.AspNetCore.Data.Steps;
using Mobioos.Scaffold.BaseGenerators.Steps;
using Mobioos.Scaffold.BaseInfrastructure.Attributes;
using WorkflowCore.Interface;

namespace Mobioos.Generators.AspNetCore
{
    [WorkFlow(Id = "AspNetCoreDataWorkflow", Order = 2)]
    public class DataWorkflow : IWorkflow
    {
        public string Id => "AspNetCoreDataWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        => builder.StartWith<DataWritingStep>()
                  .Then<WorkFlowEndStepBase>();
    }
}
