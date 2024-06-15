using System.Collections;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Range(0,100)]
    public float health = 100f;
    public float heal = 30f;
    public float damage = 10f; 
    public float healPerSecond = 1f;
    public float damagePerSecond = 1f;
    public bool isDead = false;
    
    private bool isHealing = false;
    private bool isTakingDamage = false;
    public Colorinator colorinator;
    
    private void Update()
    {
        if (!isDead) HandleHealth();
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            isDead = true;
        }
    }
    
    private void HandleHealth()
    {
        if (Input.GetKeyDown(KeyCode.H)) Heal();
        if (Input.GetKeyDown(KeyCode.J)) TakeDamage();
        if (Input.GetKeyDown(KeyCode.K)) HealOverTime(5);
        if (Input.GetKeyDown(KeyCode.L)) TakeDamageOverTime(5);
    }

    private void Heal()
    {
        health = health + heal > 100 ? 100 : health + heal;
        ApplyEffect();
    }
    
    private void TakeDamage()
    {
        health = health - damage < 0 ? 0 : health - damage;
        ApplyEffect();
    }
    
    private void HealOverTime(int seconds)
    {
        if (isHealing) return;
        StartCoroutine(HealOverTimeCoroutine(seconds));
    }

    private IEnumerator HealOverTimeCoroutine(int seconds)
    {
        isHealing = true;

        for (var i = 0; i < seconds; i++)
        {
            health = health + healPerSecond > 100 ? 100 : health + healPerSecond;
            ApplyEffect();
            yield return new WaitForSeconds(1);
        }

        isHealing = false;
    }
    
    private void TakeDamageOverTime(int seconds)
    {
        if (isTakingDamage) return;
        StartCoroutine(TakeDamageOverTimeCoroutine(seconds));
    }

    private IEnumerator TakeDamageOverTimeCoroutine(int seconds)
    {
        isTakingDamage = true;

        for (var i = 0; i < seconds; i++)
        {
            health = health - damagePerSecond < 0 ? 0 : health - damagePerSecond;
            ApplyEffect();
            yield return new WaitForSeconds(1);
        }

        isTakingDamage = false;
    }

    private void ApplyEffect()
    {
        colorinator.AdjustSaturation(health - 100f);
    }
}
