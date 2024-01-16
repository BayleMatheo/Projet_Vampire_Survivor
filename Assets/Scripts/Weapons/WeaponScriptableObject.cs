using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab
    {
        get => prefab;
        private set => prefab = value;
    }
    [SerializeField]
    float damage;
    public float Damage {get => damage; private set => damage = value;}
    [SerializeField]
    public float speed;
    public float Speed {get => speed; private set => speed = value;}
    [SerializeField]
    public float cooldownDur;
    public float CooldownDur {get => cooldownDur; private set => cooldownDur = value;}
    [SerializeField]
    public int pierce;
    public int Pierce {get => pierce ; private set => pierce = value;}
}
