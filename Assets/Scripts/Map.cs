using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private const int MapRadius = 5;
    private Dictionary<Vector2, GameObject> gameMap = new Dictionary<Vector2, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int row = -MapRadius; row <= MapRadius; row++)
        {
            for (int col = -MapRadius; col <= MapRadius; col++)
            {
                gameMap.Add(new Vector2(row, col), null);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
