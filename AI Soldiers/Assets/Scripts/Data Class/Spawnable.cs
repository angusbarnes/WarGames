using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Spawnable
{
    [Space(10)]
    public string Name;
    public TeamColor team;

    [Range(0f, 1f)]
    public float Chance = 0.5f;
    public int rolls = 3;

    public GameObject entity;

    public void Spawn(Transform[] points)
    {
        /* The points array contains the spawn boundaries for both teams:
         * BOTTOM LEFT (GREEN): Index 0
         * TOP RIGHT (GREEN): Index 1
         * BOTTOM LEFT (RED): Index 2
         * TOP RIGHT (RED): Index 3 */

        if(team == TeamColor.Green) {
            PlaceEntity(points[0], points[1]);
        }
        else if(team == TeamColor.Red) {
            PlaceEntity(points[2], points[3]);
        }
        else {
            Debug.LogError("Invalid Team Type");
        }
    }

    void PlaceEntity(Transform start, Transform end)
    {
        var x = Random.Range(start.position.x, end.position.x);
        var y = Random.Range(start.position.y, end.position.y);

        Object.Instantiate(entity, new Vector2(x, y), Quaternion.identity);
    }
}

public enum TeamColor { Red, Green}

