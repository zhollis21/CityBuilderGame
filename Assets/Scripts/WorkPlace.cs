using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkPlace : MonoBehaviour
{
    public enum WorkType { Farm, Woodcutter }

    public Slider ProgressIndicator;
    public WorkType WorkplaceType;
    public int WorkplaceLevel = 1;
    public int ProductionPerLevel = 1;
    public int ProductionCycleTime = 3;
    public int MaxWorkers = 5;

    private float productionTimer = 0;
    private List<Person> workers = new List<Person>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BackfillPositions();

        int produce = GetAmountProduced();
        if (produce > 0)
        {
            if (WorkplaceType == WorkType.Farm)
                GameManager.instance.FoodCount += produce;
            else if (WorkplaceType == WorkType.Woodcutter)
                GameManager.instance.WoodCount += produce;
        }
    }

    public void Resign(Person p)
    {
        workers.Remove(p);
    }

    private int GetAmountProduced()
    {
        int produceAmount = 0;
        float workerPercentage = workers.Count / (float)MaxWorkers;
        productionTimer += Time.deltaTime * workerPercentage;

        if (productionTimer > ProductionCycleTime)
        {
            produceAmount = ProductionPerLevel * WorkplaceLevel;

            productionTimer = 0;
        }

        ProgressIndicator.normalizedValue = productionTimer / ProductionCycleTime;

        return produceAmount;
    }

    private void BackfillPositions()
    {
        if (workers.Count < MaxWorkers)
            GameManager.instance.AddWorkplaceToRecruiterQueue(this);
    }

    public void NewHire(Person newWorker)
    {
        if (newWorker != null)
        {
            newWorker.Work = this;
            workers.Add(newWorker);
        }
    }

    private void TerminateOperations()
    {
        foreach (var worker in workers)
        {
            worker.Work = null;
        }

        Destroy(gameObject);
    }
}
