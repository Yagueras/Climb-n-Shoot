using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [field: SerializeField] public float MaxHealth { get; set; } = 10f;
    public float CurrentHealth { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

}
