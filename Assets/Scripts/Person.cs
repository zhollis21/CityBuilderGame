using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person: MonoBehaviour
{
    public House Home;
    public GameObject Work;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.AddPerson(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {

    }
}
