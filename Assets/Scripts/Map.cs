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
    private int buildingNumber = 1;
    private Dictionary<Vector2, GameObject> gameMap = new Dictionary<Vector2, GameObject>();
    private GameObject pendingBuilding;
    private SpriteRenderer pendingBuildingRenderer;
    private Color validPlacementColor = new Color(.5f, 1, .5f, 0.75f);
    private Color invalidPlacementColor = new Color(1, 0.5f, 0.5f, 0.75f);

    // Start is called before the first frame update
    void Start()
    {
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

        gameMap[Vector2.zero] = Instantiate(TownCenter, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (pendingBuilding == null)
            return;

        bool canPlaceBuilding;

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 gridPosition = new Vector2(Mathf.Round(mouseWorldPosition.x), Mathf.Round(mouseWorldPosition.y));
        pendingBuilding.transform.position = gridPosition;

        if (gameMap.ContainsKey(gridPosition) && gameMap[gridPosition] == null)
        {
            canPlaceBuilding = true;

            pendingBuildingRenderer.color = validPlacementColor;
        }
        else
        {
            canPlaceBuilding = false;

            pendingBuildingRenderer.color = invalidPlacementColor;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (canPlaceBuilding)
            {
                pendingBuildingRenderer.color = Color.white;
                gameMap[gridPosition] = pendingBuilding;
            }
            else
            {
                Destroy(pendingBuilding.gameObject);
            }

            pendingBuilding = null;
            pendingBuildingRenderer = null;
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
