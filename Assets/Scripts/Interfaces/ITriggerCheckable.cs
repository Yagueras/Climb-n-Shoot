using UnityEngine;

public interface ITriggerCheckable
{
    bool IsWithinStrikingRange { get; set; }

    bool SpawnTriggerChecked { get; set; }

    void SetStrikingDistance(bool isWithinStrikingRange);

    void EnableEnemySpawn(bool spawnTriggerChecked);
}
