using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject FarmPrefab;
    public GameObject GrassPrefab;
    public GameObject HousePrefab;
    public GameObject TownCenter;
    public GameObject WoodcutterPrefab;

    private const int MAP_RADIUS = 5;
    private int buildingNumber = 2;
    private Dictionary<Vector2, GameObject> gameMap = new Dictionary<Vector2, GameObject>();
    private GameObject pendingBuilding;
    private SpriteRenderer pendingBuildingRenderer;
    private Color validPlacementColor = new Color(.5f, 1, .5f, 0.75f);
    private Color invalidPlacementColor = new Color(1, 0.5f, 0.5f, 0.75f);

    // Start is called before the first frame update
    void Start()
    {
        // Create the map with grass tiles
        for (int col = -MAP_RADIUS; col <= MAP_RADIUS; col++)
        {
            for (int row = -MAP_RADIUS; row <= MAP_RADIUS; row++)
            {
                Vector2 position = new Vector2(col, row);

                GameObject grassSpot = Instantiate(GrassPrefab, transform);
                grassSpot.transform.position = position;

                gameMap.Add(position, null);
            }
        }

        // Put the Town Center in the center of the map
        var townCenter = Instantiate(TownCenter, transform);
        var townCenterRenderer = townCenter.GetComponent<SpriteRenderer>();
        townCenterRenderer.sortingOrder = buildingNumber++;
        gameMap[Vector2.zero] = townCenter;
    }

    // Update is called once per frame
    void Update()
    {
        // Update is used for placing buildings, so if the user isn't try to place a building we return
        if (pendingBuilding == null)
            return;

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - Camera.main.transform.position);
        Vector2 gridPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y));
        pendingBuilding.transform.position = gridPosition;

        // The building must be within the map and the tile must be empty
        if (gameMap.ContainsKey(gridPosition) && gameMap[gridPosition] == null)
        {
            pendingBuildingRenderer.color = validPlacementColor;

            // They clicked and the position is valid so place it!
            if (Input.GetMouseButtonDown(0))
            {
                pendingBuildingRenderer.color = Color.white;
                gameMap[gridPosition] = pendingBuilding;

                pendingBuilding = null;
                pendingBuildingRenderer = null;
            }
        }
        else // invalid position
        {
            pendingBuildingRenderer.color = invalidPlacementColor;

            // If they clicked while in an invalid spot we cancel the placement
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(pendingBuilding.gameObject);

                pendingBuilding = null;
                pendingBuildingRenderer = null;
            }
        }
    }

    public void CreatePendingBuilding(GameObject obj)
    {
        pendingBuilding = Instantiate(obj, transform);

        pendingBuildingRenderer = pendingBuilding.GetComponent<SpriteRenderer>();

        pendingBuildingRenderer.sortingOrder = buildingNumber++;
    }

    public void AddFarm()
    {
        CreatePendingBuilding(FarmPrefab);
    }

    public void AddHouse()
    {
        CreatePendingBuilding(HousePrefab);
    }

    public void AddWoodcutter()
    {
        CreatePendingBuilding(WoodcutterPrefab);
    }
}