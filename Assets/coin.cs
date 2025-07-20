using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    [SerializeField] float speed = 0.7f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 360 * speed * Time.deltaTime, 0));
    }
}
