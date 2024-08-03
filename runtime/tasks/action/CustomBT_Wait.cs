
using BehaviorTree.Runtime.Components;

namespace BehaviorTree.Runtime.Tasks.Action;

public partial class CustomBT_Wait : CustomBT_Action {
    private double duration = 0.0;

    public CustomBT_Wait(double duration) : this("", duration) {}
    public CustomBT_Wait(string name, double duration) : base(name) {
        this.duration = duration;
    }
    
    public override Status _Tick(double delta) {
        return elapsed < duration ? Status.RUNNING : Status.SUCCESS;
    }
}