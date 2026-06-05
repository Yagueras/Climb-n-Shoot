using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Comfort;

public class Gun : MonoBehaviour
{
    #region Gun Statistics

    [Header("Stats")]

    private float minHeatCapacity = 0f;
    [SerializeField] public float maxHeatCapacity = 20f;
    [SerializeField] public float bulletHeat = 2f;
    private float currentGunTemperature = 0f;

    #endregion

    #region Overheat timer variables
    [Header("Overheating")]

    [SerializeField] public float overheatCooldownDuration = 5f;
    [SerializeField] public float coolDownStartTimer = 0.5f;
    [SerializeField] public float coolDownSpeed = 3f;
    private bool overheated = false;

    [SerializeField] public float attackCooldownDuration = 0.2f;
    private float _currentCooldownTimer;

    private bool _attackCoolingDown;
    #endregion

    #region State Machine Variables

    public GunStateMachine StateMachine { get; set; }
    public GunCoolState CoolState { get; set; }
    public GunShootingState ShootingState { get; set; }
    public GunCoolingDownState CoolingDownState { get; set; }
    public GunOverheatedState OverheatedState { get; set; }

    #endregion

    private void Awake()
    {
        StateMachine = new GunStateMachine();

        CoolState = new GunCoolState(this, StateMachine);
        ShootingState = new GunShootingState(this, StateMachine);
        CoolingDownState = new GunCoolingDownState(this, StateMachine);
        OverheatedState = new GunOverheatedState(this, StateMachine);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StateMachine.Initialize(CoolState);
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.CurrentGunState.FrameUpdate();

    }

    public void Shoot()
    {
        if (overheated)
            return;

        if (_attackCoolingDown)
        {
            _currentCooldownTimer += Time.deltaTime;

            if (_currentCooldownTimer >= attackCooldownDuration)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, Vector3.forward, out hit))
                Debug.Log("Found an object - distance: " + hit.distance);
                ApplyHeat(bulletHeat);

            }
        }
        

        

        //TODO: SoundEffects (KaboomKablawKaboom)
    }

    private void ApplyHeat(float heat)
    {
        currentGunTemperature += heat;
        currentGunTemperature = Math.Clamp(heat, minHeatCapacity, maxHeatCapacity);
        if (currentGunTemperature >= maxHeatCapacity)
        {
            overheated = true;
        }
    }

    private void StartWeaponCooling()
    {

    }
}
