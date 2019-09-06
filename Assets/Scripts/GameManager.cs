using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int _peopleCount;
    private int _foodCount;
    private int _woodCount;

    public int PeopleCount
    {
        get => _peopleCount;
        set => _peopleCount = Mathf.Max(value, 0);
    }
    public int FoodCount
    {
        get => _foodCount;
        set => _foodCount = Mathf.Max(value, 0);
    }
    public int WoodCount
    {
        get => _woodCount;
        set => _woodCount = Mathf.Max(value, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
            Destroy(this);

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}