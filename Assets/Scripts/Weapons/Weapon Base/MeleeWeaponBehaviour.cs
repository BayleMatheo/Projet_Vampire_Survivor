using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponsBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    public float destroyAfterSeconds;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDur;
    protected float currentPierce;

    void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDur = weaponData.CooldownDur;
        currentPierce = weaponData.Pierce;
    }

    protected virtual void Start()
    {
        Destroy(gameObject,destroyAfterSeconds);
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ennemy"))
        {
            EnnemyStats ennemy = col.GetComponent<EnnemyStats>();
            ennemy.TakeDamage(currentDamage);
        }
        else if (col.CompareTag("Prop"))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
            }
        }
    }
}
