#if TOOLS
using Godot;

namespace BehaviorTree;

[Tool]
public partial class BehaviorTreePlugin : EditorPlugin {
    public override void _EnterTree() {
        // Initialization of the plugin goes here.
    }

    public override void _ExitTree() {
        // Clean-up of the plugin goes here.
    }
}
#endif