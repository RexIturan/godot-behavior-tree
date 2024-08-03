using System;
using Godot;

namespace BehaviorTree.Runtime.Components;

[GlobalClass]
public abstract partial class CustomBT_Task : Resource {
    public enum Status {
        FRESH,
        RUNNING,
        FAILURE,
        SUCCESS
    }
    
    //internal state?
    // private BehaviorTree bt
    // private Blackborad blackboard
    protected CustomBT_Blackboard Blackboard { get; set; }
    // private node agent

    // how long did the task take
    protected double elapsed = 0.0;
    
    // private Status status
    protected Status status = Status.FRESH;
    
    // private string name
    private string name;
    public string Name => $"{name} {this.GetType().Name}";

    protected CustomBT_Task() : this("") {}
    protected CustomBT_Task(string name) {
        this.name = name;
    }
    
    
    ///// Behavior Tree Functions /////

    public Status Execute(double delta) {
        if (status != Status.RUNNING) {
            _Enter();
        } else {
            elapsed += delta;
        }

        status = _Tick(delta);
        
        if (status != Status.RUNNING) {
            _Exit();
            elapsed = 0.0;
        }

        return status;
    }
    
    public void Initialize(CustomBT_Blackboard blackboard) {
        Traverse(task => task.Blackboard = blackboard);
    }
    
    public virtual void _Reset() {
        if (status == Status.RUNNING) {
            _Exit();
        }

        status = Status.FRESH;
        elapsed = 0.0;
    }
    
    public virtual void _Abort() {
        Traverse(task => task._Reset());
    }

    ///// Util /////

    public virtual void Traverse(Action<CustomBT_Task> task) {
        task.Invoke(this);
    }
    
    ///// Details /////
    /// 
    public virtual void _Setup() {}
    public virtual void _Enter() {}

    public virtual void _Exit() {}
    public abstract Status _Tick(double delta);
    
    
    
    // todo extras
    // get editor name
    // get config warning
}