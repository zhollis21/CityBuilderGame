using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public GameObject PersonPrefab;

    private int houseLevel = 1;
    private List<Person> residents = new List<Person>();
    private const int LVL_1_MAX_RESIDENTS = 5;
    private const int LVL_2_MAX_RESIDENTS = 10;
    private const int LVL_3_MAX_RESIDENTS = 15;
    private int currentMaxResidents = LVL_1_MAX_RESIDENTS;
    private const int SPAWN_RATE = 5;
    private float spawnTimer = SPAWN_RATE;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentMaxResidents <= residents.Count)
            return;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            var personObject = Instantiate(PersonPrefab, transform);

            Person personScript = personObject.GetComponent<Person>();
            personScript.Home = this;

            residents.Add(personScript);
            spawnTimer = SPAWN_RATE;
        }
    }
}