using UnityEngine;
using UnityEngine.UI;

public class HP_Player : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    [Header("UI")]
    public Slider hpBar; 

    void Start()
    {
        currentHealth = maxHealth;

        if (hpBar != null)
        {
            hpBar.maxValue = maxHealth;
            hpBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // ป้องกันค่าติดลบ
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHPBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHPBar()
    {
        if (hpBar != null)
        {
            hpBar.value = currentHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player Died");
    }
}
