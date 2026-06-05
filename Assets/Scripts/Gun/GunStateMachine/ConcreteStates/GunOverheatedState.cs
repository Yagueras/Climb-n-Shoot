using UnityEngine;

public class GunOverheatedState : GunState
{
    public GunOverheatedState(Gun gun, GunStateMachine gunStateMachine) : base(gun, gunStateMachine)
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
