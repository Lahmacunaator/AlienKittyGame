using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateState(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Walking:
                animator.SetBool("walking", true);
                animator.SetBool("hiding", false);
                animator.SetBool("jumping", false);
                break;
            case PlayerState.Idle:
                animator.SetBool("walking", false);
                animator.SetBool("hiding", false);
                animator.SetBool("jumping", false);
                break;
            case PlayerState.TimeTravelling:
                break;
            case PlayerState.Hiding:
                animator.SetBool("walking", false);
                animator.SetBool("hiding", true);
                animator.SetBool("jumping", false);
                break;
            case PlayerState.Jumping:
                animator.SetBool("hiding", false);
                animator.SetBool("jumping", true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
}

public enum PlayerState
{
    Walking,
    Idle,
    TimeTravelling,
    Hiding,
    Jumping
}
