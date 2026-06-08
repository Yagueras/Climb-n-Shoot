using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class DimorphodonManager : MonoBehaviour, IDamageable, ITriggerCheckable
{
    private float speed;
    private Transform player;
    public AudioClip raptorSound;
    public AudioSource audioSource;
    public int scoreGiven = 10;
    public SpriteRenderer spriteRenderer;
    public Color hitColor = new Color(1f, 0.3f, 0.3f);
    private bool IsWithinStrikingRange = false;

    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }
    bool ITriggerCheckable.IsWithinStrikingRange { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;
        speed = 3f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource.PlayOneShot(raptorSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //logica VIDA player
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        CurrentHealth -= damage;

        StartCoroutine(FlashRed());

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //GameManager.instance.AddScore(scoreGiven);

        //FindObjectOfType<EnemySpawner>().EnemyDied();

        Destroy(gameObject);
    }

    public void SetStrikingDistance(bool isWithinStrikingRange)
    {
        IsWithinStrikingRange = isWithinStrikingRange;
    }

    System.Collections.IEnumerator FlashRed()
    {
        spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

    public void Damage(float damageAmount)
    {
        throw new System.NotImplementedException();
    }
}
