using System.Collections;
using System.Threading;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Range(0,100)]
    public float health = 100f;
    public float heal = 30f;
    public float healPerSecond = 1f;
    public float damagePerSecond = 1f;
    public bool isDead = false;
    public Canvas HUD;
    public GameObject bloodEffectL;
    public GameObject bloodEffectR;
    
    private bool isHealing = false;
    private bool isTakingDamage = false;
    public Colorinator colorinator;
    private bool isHudUp;

    [SerializeField] private GameObject gameOverPanel;
    
    private void Update()
    {
        CheckIfDead();
    }
    
    private void CheckIfDead()
    {
        if (isDead && !isHudUp)
        {
            Instantiate(gameOverPanel, HUD.transform);
            isHudUp = true;
            Destroy(GetComponent<PlayerMover>());
        }
    }

    private void Heal()
    {
        health = health + heal > 100 ? 100 : health + heal;
        ApplyEffect();
    }
    
    public void TakeDamage(float damage)
    {
        if (health - damage <= 0) isDead = true;
        health = isDead ? 0 : health - damage;
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

    public void GetShot(bool isFromLeft = true)
    {
        TakeDamage(60);
        
        PlayBloodEffect(isFromLeft);
    }
    
    private void PlayBloodEffect(bool isFromLeft)
    {
        if (isFromLeft)
        {
            var effect = Instantiate(bloodEffectL, transform);
            Destroy(effect, 5);
        }
        else
        {
            var effect = Instantiate(bloodEffectR, transform);
            Destroy(effect, 5);
        }
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
