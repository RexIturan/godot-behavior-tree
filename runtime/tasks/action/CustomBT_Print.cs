using BehaviorTree.Runtime.Components;
using Godot;

namespace BehaviorTree.Runtime.Tasks.Action;

[GlobalClass]
public partial class CustomBT_Print : CustomBT_Action {
    [Export] private string printValue;

    public CustomBT_Print(string printValue) : this("", printValue) {}
    public CustomBT_Print(string name, string printValue): base(name) {
        this.printValue = printValue;
    }
    
    public override Status _Tick(double delta) {
        GD.Print(printValue);
        
        return Status.SUCCESS;
    }
}