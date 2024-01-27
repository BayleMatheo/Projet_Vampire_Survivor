using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    InventoryManager inventory;

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            bool randomBool = Random.Range(0, 2) == 0;

            OpenTreasureChest(randomBool);

            Destroy(gameObject);
        }
    }

    public void OpenTreasureChest(bool isHigherTier)
    {
        if (inventory.GetPossibleEvolutions().Count <= 0)
        {
            Debug.LogWarning("No Available Upgrades");
            return;
        }

        WeaponEvolutionBlueprint toEvolve = inventory.GetPossibleEvolutions()[Random.Range(0, inventory.GetPossibleEvolutions().Count)];

        inventory.EvolveWeapon(toEvolve);
    }
}
