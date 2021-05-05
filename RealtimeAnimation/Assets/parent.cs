using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parent : MonoBehaviour
{
    public GameObject[] joints;
    public Vector2[] newpos;
    public Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        joints[0].transform.localEulerAngles = new Vector3(rotation.x,rotation.y,0);
        for (int i = 0; i < joints.Length; i++)
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
        }
    }
}
