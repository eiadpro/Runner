using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sad : MonoBehaviour
{
    [SerializeField] GameObject[] waypoint;
    [SerializeField]  float speed=15f;
    int current = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print("sad "+ Vector3.Distance(transform.position, waypoint[current].transform.position));
        if (Vector3.Distance(transform.position, waypoint[current].transform.position) < 0.1f)
        {
            current++;
            print(current);
            if (current >= waypoint.Length)
            {
                current = 0;
            }
        }
        
       transform.position= Vector3.MoveTowards(transform.position, waypoint[current].transform.position, speed * Time.deltaTime);
    }
}
