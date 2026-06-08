using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioSource audioSource;
    public void PlayGame()
    {
        audioSource.PlayOneShot(clickSound);
        Debug.Log(clickSound);
        Invoke(nameof(LoadGame), 0.5f);
    }
    void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        audioSource.PlayOneShot(clickSound);
        Invoke(nameof(Quit), 0.5f);
    }

    void Quit()
    {
        Application.Quit();
    }
}
