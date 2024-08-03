using BehaviorTree.Runtime.Components;
using BehaviorTree.Runtime.Tasks.Action;
using BehaviorTree.Runtime.Tasks.BlackBoard;
using BehaviorTree.Runtime.Tasks.Composites;
using Godot;

namespace BehaviorTree.Runtime.BT;

[GlobalClass]
public partial class CustomBT_TestTree : CustomBT_SubTree {
    public CustomBT_TestTree() {
        var isMoveFalse = new CustomBT_CheckVar(
            blackboard => blackboard.TryGetValue<bool>("move", out var move) && move
        );
        
        var hasTarget = new CustomBT_CheckVar(
            blackboard => blackboard.TryGetValue<Node3D>("target", out _)
        );
        
        var reset = new CustomBT_Sequence(
            "Reset",
            new CustomBT_Fallback(
                isMoveFalse,
                new CustomBT_SetVar(blackboard => blackboard.SetValue("move", false))
            ),
            new CustomBT_Succeed()
        );

        var IfNoTargetGetTarget = new CustomBT_Fallback(
            "IfNoTargetGetTarget",
            hasTarget,
            new CustomBT_GetFirstNodeInGroup("player", "target")
        );

        // var attackOrMove = new CustomBT_Fallback(
        //     "attackOrMove",
        //     new CustomBT_Sequence(
        //         
        //     )
        // );
        
        Child = new CustomBT_Sequence(
            reset,
            IfNoTargetGetTarget
        );
    }
}