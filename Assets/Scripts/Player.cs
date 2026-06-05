using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamageable, ITriggerCheckable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 10f;
    public AudioSource audioSource;
    public AudioClip defeat;
    public Slider healthBar;
    public TMP_Text healthText;
    public float CurrentHealth { get; set; }
    public bool IsWithinStrikingRange { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {

    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        healthText.text = CurrentHealth + " / " + MaxHealth;
        healthBar.value = (float)CurrentHealth / (float)MaxHealth;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    { 
        audioSource.PlayOneShot(defeat);    
    }

    public void SetStrikingDistance(bool isWithinStrikingRange)
    {
        throw new System.NotImplementedException();
    }
}
