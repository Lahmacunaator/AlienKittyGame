using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool shouldOpen;
    public Animator animator;
    public Transform player;
    
    // Update is called once per frame
    void Update()
    {
        if (shouldOpen) return;

        if (!(Vector3.Distance(transform.position, player.position) <= 3f)) return;
        shouldOpen = true;
        animator.enabled = true;
    }
}
