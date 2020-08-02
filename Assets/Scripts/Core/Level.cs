using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new level", menuName = "Level")]
public class Level : ScriptableObject
{
    public int id;
    public int appleCount;
    public int knivesCount;
    public int minKnivesHitCount;
}
