using System;

namespace BehaviorTree.Runtime.Components;

public abstract partial class CustomBT_Decorator: CustomBT_Task {
    public CustomBT_Task Child { get; }

    public CustomBT_Decorator(CustomBT_Task child) : this("", child) {}
    public CustomBT_Decorator(string name, CustomBT_Task child): base(name) {
        Child = child;
    }
    
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