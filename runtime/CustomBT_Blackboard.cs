using Godot;
using Godot.Collections;

namespace BehaviorTree.Runtime;

public partial class CustomBT_Blackboard : Resource {
    [Export] private Dictionary<StringName, Variant> data = new();

    ///// Public Functions /////

    public bool TryGetValue<[MustBeVariant] T>(StringName key, out T result) {
        result = default;

        if (!data.TryGetValue(key, out var value)) return false;
        
        result = value.As<T>();
        return true;
    }
    
    public void SetValue<[MustBeVariant] T>(StringName key, T value) {
        if (data.ContainsKey(key)) {
            data[key] = Variant.From(value);
        } else {
            data.Add(key, Variant.From(value));
        }
    }
}