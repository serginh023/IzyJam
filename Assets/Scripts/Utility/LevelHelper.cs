using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelHelper
{
    static int currentLevel;

    public static int CurrentLevel
    {
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
        }
    }
}
