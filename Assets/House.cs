using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private int HouseLevel = 1;
    private const int LVL_1_POPULATION = 5;
    private const int LVL_2_POPULATION = 10;
    private const int LVL_3_POPULATION = 15;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.TotalPeopleCount += 5;
        GameManager.instance.AvailablePeopleCount += 5;
    }

    // Update is called once per frame
    void Update()
    {

    }
}