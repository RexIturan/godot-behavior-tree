using BehaviorTree.Runtime.Components;

namespace BehaviorTree.Runtime.Tasks.Composites;

public partial class CustomBT_Fallback : CustomBT_Composite{
    private int current = 0;

    public CustomBT_Fallback(params CustomBT_Task[] children) : this("", children) {}
    public CustomBT_Fallback(string name, params CustomBT_Task[] children) : base(name, children) {}

    public override void _Enter() {
        base._Enter();
        current = 0;
    }

    public override Status _Tick(double delta) {
        Status result = Status.SUCCESS;
        
        for (; current < children.Count; current++) {
            var child = children[current];
            result = child.Execute(delta);

            if (result != Status.FAILURE) {
                break;
            }
        }

        return result;
    }
}