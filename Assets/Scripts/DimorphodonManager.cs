using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class DimorphodonManager : MonoBehaviour
{
    private float speed;
    private Transform player;
    public AudioClip raptorSound;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
}
