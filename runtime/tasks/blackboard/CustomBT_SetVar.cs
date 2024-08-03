using System;
using BehaviorTree.Runtime.Components;

namespace BehaviorTree.Runtime.Tasks.BlackBoard;

public partial class CustomBT_SetVar : CustomBT_Action {
    private Action<CustomBT_Blackboard> action;
    
    public CustomBT_SetVar(Action<CustomBT_Blackboard> action) {
        this.action = action;
    }
    
    public override Status _Tick(double delta) {
        action.Invoke(Blackboard);
        return Status.SUCCESS;
    }
}