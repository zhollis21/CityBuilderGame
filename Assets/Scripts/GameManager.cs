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
    private List<Person> availablePopulation = new List<Person>();
    private List<WorkPlace> recruiterQueue = new List<WorkPlace>();
    private int _foodCount;
    private int _woodCount;

    public int FoodCount
    {
        get => _foodCount;
        set
        {
            _foodCount = value; //Mathf.Max(value, 0); Testing if we ever go below zero
            FoodLabel.text = $"Food: {_foodCount}";
        }
    }
    public int WoodCount
    {
        get => _woodCount;
        set
        {
            _woodCount = value; //Mathf.Max(value, 0); Testing if we ever go below zero
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
        availablePopulation = totalPopulation.FindAll(p => p.Work == null);
        DistributeRecruits();
        UpdatePopulationLabel();
    }

    private void UpdatePopulationLabel()
    {
        TotalPeopleLabel.text = $"Total Population: {totalPopulation.Count}";
        AvailablePeopleLabel.text = $"Available Population: {availablePopulation.Count}";
    }

    public void AddPerson(Person p)
    {
        totalPopulation.Add(p);
    }

    public void RemovePerson(Person p)
    {
        totalPopulation.Remove(p);
    }

    public void AddWorkplaceToRecruiterQueue(WorkPlace workToAdd)
    {
        if (recruiterQueue.Find(w => w == workToAdd) == null)
            recruiterQueue.Add(workToAdd);
    }

    public void DistributeRecruits()
    {
        while (recruiterQueue.Count > 0 && availablePopulation.Count > 0)
        {
            var workPlace = recruiterQueue[0];
            var worker = availablePopulation[0];

            workPlace.NewHire(worker);

            recruiterQueue.Remove(workPlace);
            availablePopulation.Remove(worker);
        }
    }

    public bool HasFood()
    {
        return FoodCount > 0;
    }
}