using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    
    
    public Transform vehicle;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = vehicle.position + offset;
        transform.LookAt(vehicle);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
