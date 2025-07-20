using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wawa : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name== "Cylinder")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Cylinder")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
