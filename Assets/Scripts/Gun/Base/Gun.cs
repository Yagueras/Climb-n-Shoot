using System;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] public float gunCoolDownStartTimer = 1f; // Time to wait before cooling starts
    [SerializeField] public float coolDownSpeed = 3f;
    private bool overheated = false;

    [SerializeField] public float attackCooldownDuration = 0.2f;
    private float _currentCooldownTimer;
    private bool _attackCoolingDown;

    // NEW: Dedicated timer to track how long since the last shot was fired
    private float _timeSinceLastShot;
    #endregion

    [SerializeField] public Slider gunHeatSlider;

    [SerializeField] public ParticleSystem confetti;

    public AudioClip gunshotSound;
    public AudioClip sizzlingSound;
    public AudioSource audioSource;

    private void Awake()
    {
        _currentCooldownTimer = attackCooldownDuration;
    }

    void Update()
    {
        AttackCooldown();
        StartCoolingDownWeapon();

        UpdateHeatSlider();
    }

    public void Shoot()
    {
        if (overheated)
            return;
        
        if (!_attackCoolingDown)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.forward, out hit))
            {
                // Raycast logic
            }

            ApplyHeat(bulletHeat);
            confetti.Play();
            audioSource.PlayOneShot(gunshotSound);

            // Reset attack cooldown
            _currentCooldownTimer = 0f;
            _attackCoolingDown = true;

            // NEW: Reset the shot timer so cooling pauses when you shoot
            _timeSinceLastShot = 0f;

            Debug.Log($"Shot fired! Current Temp: {currentGunTemperature}");
        }
    }

    private void ApplyHeat(float heat)
    {
        currentGunTemperature += heat;
        currentGunTemperature = Mathf.Clamp(currentGunTemperature, minHeatCapacity, maxHeatCapacity);

        if (currentGunTemperature >= maxHeatCapacity)
        {
            overheated = true;
            Debug.Log("Weapon Overheated!");
            audioSource.PlayOneShot(sizzlingSound);
        }
    }

    private void AttackCooldown()
    {
        if (_currentCooldownTimer < attackCooldownDuration)
        {
            _currentCooldownTimer += Time.deltaTime;
        }
        else
        {
            _attackCoolingDown = false;
        }
    }

    private void StartCoolingDownWeapon()
    {
        // Track how long it has been since we last shot
        _timeSinceLastShot += Time.deltaTime;

        float currentCooldownTime = gunCoolDownStartTimer;
        if (overheated)
            currentCooldownTime = overheatCooldownDuration;

        // If we haven't waited long enough, don't cool down yet
        if (_timeSinceLastShot <= currentCooldownTime)
            return;

        // Cool down using your coolDownSpeed variable, clamped so it doesn't go below min
        if (currentGunTemperature > minHeatCapacity)
        {
            currentGunTemperature -= coolDownSpeed * Time.deltaTime;
            currentGunTemperature = Mathf.Clamp(currentGunTemperature, minHeatCapacity, maxHeatCapacity);

            Debug.Log("Reducing temps: " + currentGunTemperature);

            // Optional: If you want the gun to become usable again after cooling down completely
            if (overheated && currentGunTemperature <= minHeatCapacity)
            {
                overheated = false;
                Debug.Log("Weapon cooled down. Ready to fire!");
            }
        }
    }

    private void UpdateHeatSlider()
    {
        gunHeatSlider.value = currentGunTemperature;
    }
}