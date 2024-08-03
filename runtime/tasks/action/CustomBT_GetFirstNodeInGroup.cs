using System.Linq;
using BehaviorTree.Runtime.Components;
using Godot;

namespace BehaviorTree.Runtime.Tasks.Action;

public partial class CustomBT_GetFirstNodeInGroup : CustomBT_Action {
    private string groupName = "";
    private StringName targetName;
    
    public CustomBT_GetFirstNodeInGroup(string groupName, StringName targetName, string name = "") : base(name) {
        this.groupName = groupName;
        this.targetName = targetName;
    }
    
    public override CustomBT_Task.Status _Tick(double delta) {
        if(Blackboard.TryGetValue<Node3D>("agent", out var agent)) {
            var group = agent.GetTree().GetNodesInGroup(groupName);
            if (group.Count == 0) {
                return Status.FAILURE;        
            }
            Blackboard.SetValue(targetName, group.First());
            return Status.SUCCESS;
        }
        
        return Status.FAILURE;
    }
}