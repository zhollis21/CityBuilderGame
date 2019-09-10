using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkPlace : MonoBehaviour
{
    public Slider slider;

    protected int WorkplaceLevel = 1;
    protected int productionPerLevel = 1;
    protected int cycleTime = 3;
    protected float productionTimer = 0;
    protected List<Person> workers = new List<Person>();
    protected int maxWorkers = 5;

    public void Resign(Person p)
    {
        workers.Remove(p);
    }

    protected int ProductionAmount()
    {
        int produceAmount = 0;
        float workerPercentage = workers.Count / (float)maxWorkers;
        productionTimer += Time.deltaTime * workerPercentage;

        if (productionTimer > cycleTime)
        {
            produceAmount = productionPerLevel * WorkplaceLevel;

            productionTimer = 0;
        }

        slider.normalizedValue = productionTimer / cycleTime;

        return produceAmount;
    }

    protected void BackfillPositions()
    {
        while (workers.Count < maxWorkers)
        {
            var newWorker = GameManager.instance.GetAvailablePerson();

            if (newWorker != null)
            {
                newWorker.Work = this;
                workers.Add(newWorker);
            }
            else
            {
                return; // No point in looping if there are no more available workers
            }
        }
    }
}
