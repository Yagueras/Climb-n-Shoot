using UnityEngine;

public class GunState
{
    protected Gun gun;
    protected GunStateMachine gunStateMachine;

    public GunState(Gun gun, GunStateMachine gunStateMachine)
    {
        this.gun = gun;
        this.gunStateMachine = gunStateMachine;
    }

    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }
    public virtual void PhysicsUpdate() { }
}
