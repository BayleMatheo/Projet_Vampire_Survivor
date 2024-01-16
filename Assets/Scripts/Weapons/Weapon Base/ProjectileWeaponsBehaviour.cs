using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ProjectileWeaponsBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    protected Vector3 direction;

    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDur;
    protected int currentPierce;
    
    public float destroyAfterSeconds;

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

    public void DirectionChecker(Vector3 dir)
    {
        direction = dir;

        float dirx = direction.x;
        float diry = direction.y;

        Vector3 scale = transform.localScale;
        Vector3 rotation = transform.rotation.eulerAngles;

        if (dirx < 0 && diry == 0) //left
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry < 0 ) // down
        {
            scale.y = scale.y * -1;
        }
        else if (dirx == 0 && diry > 0 ) // up
        {
            scale.x = scale.x * -1;
        }        
        else if (dir.x > 0 && dir.y > 0 ) // right up
        {
            rotation.z = 0f;
        }
        else if (dir.x > 0 && dir.y < 0 ) // right down
        {
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y > 0 ) // left up
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = -90f;
        }
        else if (dir.x < 0 && dir.y < 0 ) // left down
        {
            scale.x = scale.x * -1;
            scale.y = scale.y * -1;
            rotation.z = 0f;
        }

        transform.localScale = scale;
        transform.rotation = Quaternion.Euler(rotation); 
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ennemy"))
        {
            EnnemyStats ennemy = col.GetComponent<EnnemyStats>();
            ennemy.TakeDamage(currentDamage);
            ReducePierce();
        }
        else if (col.CompareTag("Prop"))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
                ReducePierce();
            }
        }
    }

    void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
