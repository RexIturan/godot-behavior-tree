using BehaviorTree.Runtime.Components;

namespace BehaviorTree.Runtime.Tasks.Action;

public partial class CustomBT_Succeed : CustomBT_Action {
    public override Status _Tick(double delta) {
        return Status.SUCCESS;
    }
}