using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodcutter : MonoBehaviour
{
    private int WoodcutterLevel = 1;
    private const int LVL_1_PRODUCTION = 1;
    private const int LVL_2_PRODUCTION = 2;
    private const int LVL_3_PRODUCTION = 3;
    private const int CYCLE_TIME = 5;
    private float productionTimer = CYCLE_TIME;
    private int currentProduction = LVL_1_PRODUCTION;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        productionTimer -= Time.deltaTime;

        if (productionTimer < 0)
        {
            GameManager.instance.WoodCount += currentProduction;

            productionTimer = CYCLE_TIME;
        }
    }
}