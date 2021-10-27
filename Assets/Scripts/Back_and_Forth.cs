using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_and_Forth : MonoBehaviour
{
    public float speed = 3.0f;
    public float maxZ = 16.0f;
    public float minZ = -16.0f;
    public int _direction = 1;
    void Update()
    {
        transform.Translate(0, 0, _direction * speed * Time.deltaTime);
        bool bounce = false;
        if (transform.position.z > maxZ || transform.position.z < minZ)
        {
            _direction = -_direction;
            bounce = true;
        }
        if (bounce)
        {
            transform.Translate(0, 0, _direction * speed * Time.deltaTime);
        }
    }
}
