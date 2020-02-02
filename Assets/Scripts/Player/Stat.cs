using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    private string statName;
    private int statValue;

    public Stat(string _statName, int _statValue) {
        statName = _statName;
        statValue = _statValue;
    }

    public void IncreaseStat(int value) {
        statValue += value;
    }

    public void DecraseStat(int value) {
        statValue -= value;
    }

    public int GetValue() {
        return statValue;
    }

    public string GetStatName() {
        return statName;
    }
}
