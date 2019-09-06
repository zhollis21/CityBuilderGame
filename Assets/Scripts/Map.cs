using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject FarmPrefab;
    public GameObject HousePrefab;
    public GameObject TownCenter;
    public GameObject WoodcutterPrefab;

    private const int MapRadius = 5;
    private Dictionary<Vector2, GameObject> gameMap = new Dictionary<Vector2, GameObject>();
    private GameObject pendingBuilding;

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

        gameMap[Vector2.zero] = Instantiate(TownCenter);
    }

    // Update is called once per frame
    void Update()
    {
        if (pendingBuilding == null)
            return;

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pendingBuilding.transform.position = mouseWorldPosition;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            pendingBuilding = null;
        }
    }

    public void AddFarm()
    {
        pendingBuilding = Instantiate(FarmPrefab);        
    }

    public void AddHouse()
    {
        pendingBuilding = Instantiate(HousePrefab);
    }

    public void AddWoodcutter()
    {
        pendingBuilding = Instantiate(WoodcutterPrefab);
    }
}
