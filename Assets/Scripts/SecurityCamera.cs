using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Speed of rotation
    public float rotationAngle = 45.0f; // Angle to rotate to each time
    public float waitTime = 2.0f;       // Time to wait at each spot

    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        StartCoroutine(RotateCamera());
    }

    IEnumerator RotateCamera()
    {
        while (true)
        {
            // Rotate to the right
            yield return RotateToAngle(rotationAngle);
            yield return new WaitForSeconds(waitTime);

            // Rotate back to the initial position
            yield return RotateToAngle(0);
            yield return new WaitForSeconds(waitTime);

            // Rotate to the left
            yield return RotateToAngle(-rotationAngle);
            yield return new WaitForSeconds(waitTime);

            // Rotate back to the initial position
            yield return RotateToAngle(0);
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator RotateToAngle(float targetAngle)
    {
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0) * initialRotation;
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = targetRotation; // Ensure the final rotation is exact
    }
}