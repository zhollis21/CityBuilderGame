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

    private List<Person> totalPopulation = new List<Person>();
    private int _foodCount;
    private int _woodCount;

    public int FoodCount
    {
        get => _foodCount;
        set
        {
            _foodCount = Mathf.Max(value, 0);
            FoodLabel.text = $"Food: {_foodCount}";
        }
    }
    public int WoodCount
    {
        get => _woodCount;
        set
        {
            _woodCount = Mathf.Max(value, 0);
            WoodLabel.text = $"Wood: {_woodCount}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
            Destroy(this);

        WoodCount = 20;
        FoodCount = 20;

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var availablePopulation = totalPopulation.FindAll(p => p.Work == null);
        SetPopulationLabel(availablePopulation.Count);
    }

    private void SetPopulationLabel(int availablePopulationCount)
    {
        TotalPeopleLabel.text = $"Total Population: {totalPopulation.Count}";
        AvailablePeopleLabel.text = $"Available Population: {availablePopulationCount}";
    }

    public void AddPerson(Person p)
    {
        totalPopulation.Add(p);
    }

    public void RemovePerson(Person p)
    {
        totalPopulation.Remove(p);
    }

    public Person GetAvailablePerson()
    {
        return totalPopulation.Find(p => p.Work == null);
    }

    public bool HasFood()
    {
        return FoodCount > 0;
    }
}