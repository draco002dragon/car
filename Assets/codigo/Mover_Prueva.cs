using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Prueva : MonoBehaviour
{
    public float veloz = 10f;
    public float ja = 100f;
    private Rigidbody rb;

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");


        Vector3 move = transform.forward * moveInput * veloz * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);

        float turn = turnInput * ja * Time.fixedDeltaTime;
        Quaternion rotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * rotation);
    }
}
