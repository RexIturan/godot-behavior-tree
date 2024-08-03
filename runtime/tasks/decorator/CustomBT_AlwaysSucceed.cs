using BehaviorTree.Runtime.Components;

namespace BehaviorTree.Runtime.Tasks.Decorator;

public partial class CustomBT_AlwaysSucceed : CustomBT_Decorator {
    public CustomBT_AlwaysSucceed(CustomBT_Task child) : base(child) {}
    public CustomBT_AlwaysSucceed(string name, CustomBT_Task child) : base(name, child) {}
    
    ///// Override /////
    public override Status _Tick(double delta) {
        return base._Tick(delta) == Status.RUNNING ? Status.RUNNING : Status.SUCCESS;
    }
}