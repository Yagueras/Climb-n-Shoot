using UnityEngine;

public interface ITriggerCheckable
{
    bool IsWithinStrikingRange { get; set; }

    void SetStrikingDistance(bool isWithinStrikingRange);
}
