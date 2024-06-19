using System.Collections;
using UnityEngine;

public class ElectricField : MonoBehaviour
{
    public float interval = 1.0f; // Interval in seconds
    private Coroutine triggerCoroutine;
    public HealthManager healthManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Triggered: {other.name}");
        if (other.CompareTag("Player")) // Or any other tag to identify the object
        {
            // Start the coroutine when the object enters the zone
            triggerCoroutine = StartCoroutine(TriggerFunctionRoutine());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Or any other tag to identify the object
        {
            // Stop the coroutine when the object exits the zone
            if (triggerCoroutine != null)
            {
                StopCoroutine(triggerCoroutine);
                triggerCoroutine = null;
            }
        }
    }

    private IEnumerator TriggerFunctionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            TriggerFunction();
        }
    }

    private void TriggerFunction()
    {
        healthManager.TakeDamage(20f);
    }
}