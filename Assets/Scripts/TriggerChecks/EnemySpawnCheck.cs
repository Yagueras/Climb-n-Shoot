using UnityEngine;

public class EnemySpawnCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; }
    private DimorphodonManager _enemy;

    private void Awake()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");

        //_enemy = GetComponentInParent<Enemy>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerTarget)
        {
            _enemy.EnableEnemySpawn(true);
        }
    }
}
