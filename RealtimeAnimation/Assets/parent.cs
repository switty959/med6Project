using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent : MonoBehaviour
{
    public GameObject[] joints;
    public Vector2[] newpos;
    public Transform[] parents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < joints.Length; i++)
        {
            if (joints[i].name != "shoulder")
            {
                joints[i].transform.parent = null;
            }
            joints[i].transform.position = newpos[i];
            if (joints[i].name != "shoulder")
            {
                joints[i].transform.parent = parents[i];
                joints[i].transform.localPosition = newpos[i];
            }

        }
       /* for (int i = 0; i < joints.Length; i++)
        {
            if (i==0)
            {
                joints[i].transform.position = newpos[0];
            }
            else if (i == 1)
            {
                joints[i].transform.position = (newpos[1]+ newpos[0])/2;
            }
            else if (i == 2)
            {
                joints[i].transform.position = newpos[1];
            }
        }*/
    }
}
