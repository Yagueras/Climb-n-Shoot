using UnityEngine;

public class TrophyController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winSound;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(winSound);
    }
}
