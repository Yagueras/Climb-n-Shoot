using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamageable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 10f;
    public AudioSource audioSource;
    public AudioClip defeat;
    public Slider healthBar;
    public TMP_Text healthText;
    public float CurrentHealth { get; set; }

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
}
