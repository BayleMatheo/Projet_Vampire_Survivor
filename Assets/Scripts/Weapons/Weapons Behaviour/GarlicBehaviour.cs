using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicBehaviour : MeleeWeaponsBehaviour
{
    List<GameObject> markedEnnemies;
    
    protected override void Start()
    {
        base.Start();
        markedEnnemies = new List<GameObject>();
    }
    
    protected void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ennemy") && !markedEnnemies.Contains(col.gameObject))
        {
            EnnemyStats ennemy = col.GetComponent<EnnemyStats>();
            ennemy.TakeDamage(currentDamage);
        
            markedEnnemies.Add(col.gameObject);
        }
        else if (col.CompareTag("Prop") && !markedEnnemies.Contains(col.gameObject))
        {
            if (col.gameObject.TryGetComponent(out BreakableProps breakable))
            {
                breakable.TakeDamage(currentDamage);
                
                markedEnnemies.Add(col.gameObject);
            }
        }

    }
    
}
