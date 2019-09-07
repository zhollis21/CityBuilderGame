using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text TotalPeopleLabel;
    public Text AvailablePeopleLabel;
    public Text FoodLabel;
    public Text WoodLabel;

    public static GameManager instance;
    private int _totalPeopleCount;
    private int _availablePeopleCount;
    private int _foodCount;
    private int _woodCount;

    public int TotalPeopleCount
    {
        get => _totalPeopleCount;
        set
        {
            _totalPeopleCount = Mathf.Max(value, 0);
            TotalPeopleLabel.text = $"Total People: {_totalPeopleCount}";
        }
    }
    public int AvailablePeopleCount
    {
        get => _availablePeopleCount;
        set
        {
            _availablePeopleCount = Mathf.Max(value, 0);
            AvailablePeopleLabel.text = $"Total People: {_availablePeopleCount}";
        }
    }
    public int FoodCount
    {
        get => _foodCount;
        set
        {
            _foodCount = Mathf.Max(value, 0);
            FoodLabel.text = $"Total People: {_foodCount}";
        }
    }
    public int WoodCount
    {
        get => _woodCount;
        set
        {
            _woodCount = Mathf.Max(value, 0);
            WoodLabel.text = $"Total People: {_woodCount}";
        }
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