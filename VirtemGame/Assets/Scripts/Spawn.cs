using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Capsula;
    private int count=0;
    public int number = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)==true)
        {
            for (int i = 0; i < number; i++)
            {
                GameObject thing = Instantiate(Capsula, transform.position, transform.rotation);
                thing.name = "Capsula" + count++;
            }
        }
    }
}
