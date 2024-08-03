using BehaviorTree.Runtime.Components;
using Godot;

namespace BehaviorTree.Runtime;

[GlobalClass]
public partial class CustomBehaviorTree: Resource {
    [Export] private CustomBT_Task root;
    public CustomBT_Task Tree => root;

    public void Initialize(CustomBT_Blackboard blackboard) {
        root.Initialize(blackboard);
    }
}