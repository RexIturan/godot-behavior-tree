using System;
using Godot;
using Godot.Collections;

namespace BehaviorTree.Runtime.Components;

public abstract partial class CustomBT_Composite : CustomBT_Task {
    [Export] protected Array<CustomBT_Task> children;
    public Array<CustomBT_Task> Children => children;

    public CustomBT_Composite(string label = "", params CustomBT_Task[] children) : base(label) {
        this.children = new Array<CustomBT_Task>();//children.Length);
        this.children.AddRange(children);
    }

    ///// Overrides /////

    public override void _Enter() {
        if (status != Status.FRESH) {
            foreach (var child in children) {
                child._Abort();
            }
        }
    }

    public override void Traverse(Action<CustomBT_Task> task) {
        base.Traverse(task);
        foreach (var child in children) {
            child.Traverse(task);
        }
    }
}