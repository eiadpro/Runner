using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ani : MonoBehaviour
{
    Transform t;
    [SerializeField] Transform c;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        t.localRotation=c.localRotation;
        t.position = new Vector3(c.position.x, c.position.y-1f, c.position.z);
    }
}
