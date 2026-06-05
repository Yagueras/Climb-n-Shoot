using UnityEngine;

public class GunShootingState : GunState
{
    public GunShootingState(Gun gun, GunStateMachine gunStateMachine) : base(gun, gunStateMachine)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}