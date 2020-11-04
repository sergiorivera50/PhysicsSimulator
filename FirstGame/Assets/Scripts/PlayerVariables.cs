using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariables : MonoBehaviour
{
    public static bool emptyHands;
    public static bool timeIsPaused;

    void Start()
    {
        emptyHands = true;
        timeIsPaused = false;
    }
}
