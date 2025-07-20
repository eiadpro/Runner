using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    int s;
    bool check;
    // Start is called before the first frame update
    void Start()
    {
         s = 0;
        check = true;
    }

    // Update is called once per frame
    void Update()
    {
       
         
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f,0f,0.05f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, 0f, -0.05f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.05f, 0f, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.05f, 0f, 0);
        }
        print(check);
        if (check )
        {
            if(Input.GetKey(KeyCode.Space)) {
                print(check);
                s++;
                transform.Translate(0, 0.05f, 0);
                print("sad is " + s);

                if (s >= 70)
                    check = false;
            }
            else if (!Input.GetKey(KeyCode.Space) && s!=0)
            {
                    check = false;
            }

        }

       else if (!check&& s > 0)
        {
            print("sad is " + s);
            s--;
            transform.Translate(0, -0.05f, 0);
            if (s <= 0)
            {
                check = true;
            }
        }
        
       
    }
}
