using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using OrbitalElements;

public class CarTrajectory : MonoBehaviour
{
    float timeCounter = 0;
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime*0.25f;

        float x = Mathf.Sin(timeCounter) * 300 * 1.1f;
        float y = Mathf.Cos(timeCounter) * 600 * 1.2f;
        float z = (Mathf.Sin(timeCounter) + Mathf.Cos(timeCounter)) * 100;

        transform.position = new Vector3(x, y, z);
       
    }
}
