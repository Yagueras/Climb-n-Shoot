using System.Threading;
using UnityEngine;

public class Holster : MonoBehaviour
{
    [SerializeField]public GameObject centerEyeAnchor;
    private float rotateSpeed = 50;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(centerEyeAnchor.transform.position.x, centerEyeAnchor.transform.position.y/2, centerEyeAnchor.transform.position.z);

        var rotationDifference = Mathf.Abs(centerEyeAnchor.transform.eulerAngles.y - transform.eulerAngles.y);
        var finalRotationSpeed = rotateSpeed;

        if (rotationDifference > 60)
        {
            finalRotationSpeed = rotateSpeed * 2;
        }
        else if (rotationDifference > 40 && rotationDifference < 60)
        {
            finalRotationSpeed = rotateSpeed;
        }
        else if (rotationDifference < 40 && rotationDifference > 20)
        {
            finalRotationSpeed = rotateSpeed / 2;
        }
        else if (rotationDifference < 20 && rotationDifference > 0)
        {
            finalRotationSpeed = rotateSpeed / 4;
        }

        var step = finalRotationSpeed *Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, centerEyeAnchor.transform.eulerAngles.y, 0),step);
    }
}
