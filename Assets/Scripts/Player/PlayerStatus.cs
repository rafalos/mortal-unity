using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] int minimumDamage = 10;
    [SerializeField] int maximumDamage = 30;
    [SerializeField] float defence = 20f;
    [SerializeField] float fireResistance = 5f;
    [SerializeField] float coldResistance = 5f;
    [SerializeField] float darknessResistance = 5f;


    public int GetPlayerMinimumDamage() {
        return minimumDamage;
    }

    public int GetPlayerMaximumDamage() {
        return maximumDamage;
    }
}
