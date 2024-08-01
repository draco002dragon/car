using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto2 : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 100f;

    void Update()
    {
        // Movimiento hacia adelante y hacia atrás
        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(0, 0, move);

        // Rotación
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);
    }
}
