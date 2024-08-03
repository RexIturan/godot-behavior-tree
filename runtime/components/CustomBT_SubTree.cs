using System;

namespace BehaviorTree.Runtime.Components;

public partial class CustomBT_SubTree : CustomBT_Task {
    protected CustomBT_Task Child { get; set; }

    public CustomBT_SubTree() : base("") {}
    public CustomBT_SubTree(string name) : base(name) {}
    
    ///// Overrides /////

    public override void _Enter() {
        if (status != Status.FRESH) {
            Child._Abort();
        }
    }

    public override Status _Tick(double delta) {
        return Child.Execute(delta);
    }
    
    public override void Traverse(Action<CustomBT_Task> task) {
        task.Invoke(this);
        Child.Traverse(task);
    }
}