using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] playerPosition;

    public PlayerData (Vector2 position)
    {
        playerPosition = new float[2];
        playerPosition[0] = position.x;
        playerPosition[1] = position.y;

    }
}
