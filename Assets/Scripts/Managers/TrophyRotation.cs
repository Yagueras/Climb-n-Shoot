using UnityEngine;

public class TrophyRotation : MonoBehaviour
{
    private float velocidadRotacion = 144f; // grados por segundo

    void Update()
    {
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }
}
