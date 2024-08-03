namespace BehaviorTree.Runtime.Components;

public abstract partial class CustomBT_Condition : CustomBT_Task {
    protected abstract bool Evaluate();

    public override Status _Tick(double delta) {
        return Evaluate() ? Status.SUCCESS : Status.FAILURE;
    }
}