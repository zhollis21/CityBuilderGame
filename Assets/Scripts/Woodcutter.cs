using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodcutter : WorkPlace
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BackfillPositions();

        int produce = ProductionAmount();
        if (produce > 0)
            GameManager.instance.WoodCount += produce;
    }
}