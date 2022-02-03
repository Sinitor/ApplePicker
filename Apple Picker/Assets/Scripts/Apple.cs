using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public int value = 1;
    float bottomY = -6f;

     void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(gameObject);
        }
    }
}
