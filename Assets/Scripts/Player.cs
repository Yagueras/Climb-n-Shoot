using UnityEngine;
using TMPro;
using UnityEngine.UI; // CAMBIADO: De UnityEngine.UIElements a UnityEngine.UI

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

        // Es una buena práctica inicializar el texto y la barra al empezar la partida
        if (healthText != null)
            healthText.text = CurrentHealth + " / " + MaxHealth;
        if (healthBar != null)
            healthBar.value = CurrentHealth / MaxHealth;
    }

    void Update()
    {

    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        // Añadimos comprobaciones de seguridad para que el juego no se rompa si olvidas asignarlos
        if (healthText != null)
        {
            healthText.text = CurrentHealth + " / " + MaxHealth;
        }

        if (healthBar != null)
        {
            healthBar.value = (float)CurrentHealth / (float)MaxHealth;
        }

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (audioSource != null && defeat != null)
        {
            audioSource.PlayOneShot(defeat);
        }
    }
}