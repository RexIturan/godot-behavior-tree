using Godot;

namespace BehaviorTree.Runtime;

public partial class CustomBTPlayer: Node {
    [Export] public bool Active { get; set; }
    [Export] private CustomBT_Blackboard blackboard;
    [Export] private CustomBehaviorTree behaviorTree;
    [Export] private Node3D agent;

    private bool initialized = false;
    
    ///// Godot Functions /////
    
    public override void _EnterTree() {
        base._EnterTree();

        blackboard = new CustomBT_Blackboard();
        blackboard.SetValue("agent", agent);
        behaviorTree.Initialize(blackboard);
        initialized = true;
    }

    ///// Public Functions /////
    
    public void Update(float delta) {
        if(!Active || !initialized) return;
        
        //do stuff
        var status = behaviorTree.Tree.Execute(delta);
    }
}