using BehaviorTree.Runtime.Components;
using BehaviorTree.Runtime.Tasks.Action;
using Godot;

namespace BehaviorTree.Components.BT;

[GlobalClass]
public partial class GetTargetSubtree : CustomBT_SubTree {
    [Export] public CustomBT_Task Child { get; private set; }
    
    public GetTargetSubtree() : base("GetTargetSubtree") {
        // Child = new CustomBT_Sequence(
        //     new CustomBT_CheckVar(blackboard => blackboard.TryGetValue<Node3D>("target", out _)),
        //     new CustomBT_GetFirstNodeInGroup(groupName: "player", targetName: "target")
        // );
        Child = new CustomBT_Print("test From Init!");
    }
    
    ///// Overrides /////

    public override Status _Tick(double delta) {
        return Child.Execute(delta);
    }
}