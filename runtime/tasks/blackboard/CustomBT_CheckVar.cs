using System;
using BehaviorTree.Runtime.Components;

namespace BehaviorTree.Runtime.Tasks.BlackBoard;

public partial class CustomBT_CheckVar : CustomBT_Condition {
    private Func<CustomBT_Blackboard, bool> action;

    public CustomBT_CheckVar(Func<CustomBT_Blackboard, bool> action) {
        this.action = action;
    }
    
    protected override bool Evaluate() {
        return action.Invoke(Blackboard);
    }
}