using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    private float roamingDirection = -1;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private float cooldownTimer;
    private Moves currentMove;
    
    
    [Header("Settings")]
    public float directionCooldown = 5f;
    public float moveSpeed = 5f;
    public float detectionRange = 10f;
    public HealthManager playerHealth;
    public int attackCooldown = 3;
    private float attackCooldownTimer = 0f;
    public bool isMonster;
    
    [Header("Animator Params")]
    public bool isWalking;
    public bool isAttacking;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleDirection();
        CheckPlayer();
        attackCooldownTimer += Time.deltaTime;
    }

    private void CheckPlayer()
    {
        var distance = transform.position.x - playerHealth.transform.position.x;
        if (Mathf.Abs(distance) <=  detectionRange && attackCooldownTimer >= attackCooldown)
        {
            currentMove = EngageAttack(distance < 0);
            attackCooldownTimer = 0f;
        }
    }

    public void OnAttackAnimationEnd()
    {
        currentMove = DecideMovement();
    }

    private Moves EngageAttack(bool isFromLeft)
    {
        StopMovement();
        LookAtPlayer();
        animator.SetBool("attacking", true);
        playerHealth.GetShot(isFromLeft);
        return Moves.Attack;
    }

    private void LookAtPlayer()
    {
        if (playerHealth.transform.position.x < transform.position.x)
        {
            roamingDirection = -1;
            sr.flipX = isMonster;
        }
        else
        {
            roamingDirection = 1;
            sr.flipX = !isMonster;
        }
    }

    private void HandleDirection()
    {
        if (cooldownTimer >= directionCooldown)
        {
            cooldownTimer = 0f;
            currentMove = DecideMovement();
        }

        cooldownTimer += Time.deltaTime;
    }

    private Moves DecideMovement()
    {
        var random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                StopMovement();
                return Moves.Wait;
            case 1:
                StopMovement();
                UpdateDirection();
                StartMovement();
                return Moves.Move;
            default:
                return Moves.Wait;;
        }
    }

    private void StartMovement()
    {
        animator.SetBool("walking", true);
        animator.SetBool("attacking", false);
    }

    private void StopMovement()
    {
        animator.SetBool("walking", false);
        animator.SetBool("attacking", false);
        rb.velocity = Vector2.zero;
    }

    private void HandleMovement()
    {
        if (currentMove != Moves.Move) return;
        var moveVelocity = new Vector2(roamingDirection * moveSpeed, rb.velocity.y);
        rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y); 
    }

    private void UpdateDirection()
    {
        var wasLeft = roamingDirection == -1;
        if (wasLeft)
        {
            roamingDirection = 1;
            sr.flipX = true;
        }
        else
        {
            roamingDirection = -1;
            sr.flipX = false;
        }
    }
}

public enum Moves
{
    Attack,
    Move,
    Wait
}