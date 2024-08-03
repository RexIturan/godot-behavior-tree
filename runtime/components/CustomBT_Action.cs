namespace BehaviorTree.Runtime.Components;

public abstract partial class CustomBT_Action : CustomBT_Task {
    public CustomBT_Action() : base("") {}
    public CustomBT_Action(string name) : base(name) {}
}