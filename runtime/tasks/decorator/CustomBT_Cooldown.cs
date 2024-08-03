using BehaviorTree.Runtime.Components;

namespace BehaviorTree.Runtime.Tasks.Decorator;

public partial class CustomBT_Cooldown : CustomBT_Decorator {
    private double cooldown = 0.0;
    
    public CustomBT_Cooldown(double cooldown, CustomBT_Task child) :
        this("", cooldown, child) {}

    public CustomBT_Cooldown(string name, double cooldown, CustomBT_Task child) :
        base(name, child) {
        this.cooldown = cooldown;
    }

    ///// Override /////
    
    public override Status _Tick(double delta) {
        return base._Tick(delta);
    }
}