using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {
    public static int GetRandomIntInRange(int min, int max) {
        return Random.Range(min, max);
    }

    public static float GetRandomFloatInRange(float min, float max) {
        return Random.Range(min, max);
    }
}
