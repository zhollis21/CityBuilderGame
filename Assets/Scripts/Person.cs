using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person: MonoBehaviour
{
    public House Home;
    public WorkPlace Work;

    private const int HUNGER_CYCLE_TIME = 30;
    private float hungerTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.AddPerson(this);

        Eat();
    }

    // Update is called once per frame
    void Update()
    {
        hungerTimer += Time.deltaTime;

        if (hungerTimer > HUNGER_CYCLE_TIME)
        {
            Eat();
        }
    }

    private void Eat()
    {
        if (GameManager.instance.HasFood())
        {
            // Mmmm... Grub time
            GameManager.instance.FoodCount--;
            hungerTimer = 0;
        }
        else
        {
            // If there is no food, we starve
            Die();
        }
    }

    public void Die()
    {
        if (Work != null)
            Work.Resign(this);

        if (Home != null)
            Home.Runaway(this);

        GameManager.instance.RemovePerson(this);
        Destroy(gameObject);
    }
}
