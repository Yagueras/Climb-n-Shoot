using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    [Header("Enemigos a Activar")]
    [Tooltip("Arrastra aquí los GameObjects de los enemigos que quieres activar al tocar este trigger.")]
    [SerializeField] private GameObject[] enemiesToSpawn;

    // Esta variable evita que el spawn se ejecute varias veces si el jugador entra y sale del área
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el collider que entra es el jugador y si no se ha activado antes
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true; // Lo marcamos como activado

            // Recorremos la lista de enemigos y los activamos
            foreach (GameObject enemy in enemiesToSpawn)
            {
                if (enemy != null)
                {
                    enemy.SetActive(true);
                }
            }

            // Opcional: Como este trigger ya ha cumplido su función, podemos destruirlo para ahorrar recursos
            Destroy(gameObject);
        }
    }
}