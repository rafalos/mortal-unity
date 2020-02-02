using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loot Table")]
public class LootTable : ScriptableObject
{
    [SerializeField] Item[] lootList;

    public Item GetRandomItem() {
        return lootList[5];
    }
}
