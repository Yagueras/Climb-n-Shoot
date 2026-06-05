using UnityEngine;

public class GunStateMachine
{
    public GunState CurrentGunState { get; set; }

    public void Initialize(GunState startingState)
    {
        CurrentGunState = startingState;
        CurrentGunState.EnterState();
    }

    public void ChangeState(GunState newState)
    {
        CurrentGunState.ExitState();
        CurrentGunState = newState;
        CurrentGunState.EnterState();
    }
}
