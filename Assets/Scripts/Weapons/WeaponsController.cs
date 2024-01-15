using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")] 
    public GameObject prefab;

    public float damage;
    public float speed;
    public float cooldownDur;
    private float currentCooldown;
    public int pierce;
    protected PlayerMovement playerMovement;
    protected virtual void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        currentCooldown = cooldownDur;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown < 0f)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = cooldownDur;
    }
}
