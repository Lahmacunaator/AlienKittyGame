using System;
using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Speed of rotation
    public float rotationAngle = 45.0f; // Angle to rotate to each time
    public float waitTime = 2.0f;       // Time to wait at each spot

    public GameObject[] electricityAreas;
    private Quaternion initialRotation;

    void Start()
    {
        initialRotation = transform.rotation;
        StartCoroutine(RotateCamera());
    }

    private void OnEnable()
    {
        StartCoroutine(RotateCamera());
    }

    IEnumerator RotateCamera()
    {
        while (true)
        {
            // Rotate to the right
            yield return RotateToAngle(rotationAngle);
            SetFieldActive(2);
            yield return new WaitForSeconds(waitTime);
            TurnFieldOff(2);
            
            // Rotate back to the initial position
            yield return RotateToAngle(0);
            SetFieldActive(0);
            yield return new WaitForSeconds(waitTime);
            TurnFieldOff(0);

            // Rotate to the left
            yield return RotateToAngle(-rotationAngle);
            SetFieldActive(1);
            yield return new WaitForSeconds(waitTime);
            TurnFieldOff(1);

            // Rotate back to the initial position
            yield return RotateToAngle(0);
            SetFieldActive(0);
            yield return new WaitForSeconds(waitTime);
            TurnFieldOff(0);
        }
    }

    public void StopCameraMovement()
    {
        StopAllCoroutines();
    }

    private void SetFieldActive(int index)
    {
        for (var i = 0; i < electricityAreas.Length; i++)
        {
            electricityAreas[i].SetActive(i == index);
        }
    }

    private void TurnFieldOff(int index)
    {
        electricityAreas[index].SetActive(false);
    }

    IEnumerator RotateToAngle(float targetAngle)
    {
        var targetRotation = Quaternion.Euler(0, 0, targetAngle) * initialRotation;
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = targetRotation; // Ensure the final rotation is exact
    }

    private void OnDisable()
    {
        StopCameraMovement();
    }
}