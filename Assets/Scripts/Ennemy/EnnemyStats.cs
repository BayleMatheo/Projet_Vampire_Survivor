using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyStats : MonoBehaviour
{
    public EnnemyScriptableObject ennemyData;
    private float currentMoveSpeed;
    private float currentHealth;
    private float currentDamage;

    void Awake()
    {
        currentMoveSpeed = ennemyData.MoveSpeed;
        currentHealth = ennemyData.MaxHealth;
        currentDamage = ennemyData.Damage;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
}
