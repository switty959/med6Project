using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointScript : MonoBehaviour
{
    public GameObject[] arrayOfJoints;
    public GameObject joint;
    public Transform parent;
    public Server server;
    // Start is called before the first frame update
    void Start()
    {
        arrayOfJoints = new GameObject[server.positionForJoints.Length];
        for (int i = 0; i < arrayOfJoints.Length; i++)
        {
            arrayOfJoints[i] = Instantiate(joint, parent);
            arrayOfJoints[i].name = i.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < arrayOfJoints.Length; i++)
        {

            arrayOfJoints[i].transform.position = server.positionForJoints[i];
        }
    }
}
