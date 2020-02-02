using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour {

    public Stat speed = new Stat("Movement Speed", 4);
    public float playerDamage { get; set; } = 10f;

    public float GetPlayerDamage() {
        return playerDamage;
    }

    public float GetPlayerMovementSpeed() {
        return speed.GetValue();
    }
}


