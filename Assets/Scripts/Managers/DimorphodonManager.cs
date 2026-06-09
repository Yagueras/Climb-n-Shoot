using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DimorphodonManager : MonoBehaviour, IDamageable, ITriggerCheckable
{
    private float speed;
    private GameObject player;
    public AudioClip raptorSound;
    public AudioSource audioSource;
    public int scoreGiven = 10;
    public SpriteRenderer spriteRenderer;
    public Color hitColor = new Color(1f, 0.3f, 0.3f);

    [field: SerializeField] public float MaxHealth { get; set; } = 50f;
    public float CurrentHealth { get; set; }
    public bool IsWithinStrikingRange { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = MaxHealth;
        speed = 0.5f;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource.PlayOneShot(raptorSound);
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += speed * Time.deltaTime * direction;
        transform.LookAt(player.transform);
    }

    // CAMBIO: De OnCollisionEnter a OnTriggerEnter porque el SphereCollider es un Trigger
    private void OnTriggerEnter(Collider other)
    {
        // CAMBIO: Usar 'other.gameObject' en lugar de 'collision.gameObject'
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<IDamageable>().Damage(30f);
            //Destroy(gameObject);
        }
    }

    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

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
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    public void SetStrikingDistance(bool isWithinStrikingRange)
    {
        IsWithinStrikingRange = isWithinStrikingRange;
    }

    System.Collections.IEnumerator FlashRed()
    {
        //spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        //spriteRenderer.color = Color.white;
    }
}
