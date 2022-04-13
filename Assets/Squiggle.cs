using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squiggle : MonoBehaviour
{
    [SerializeField] Vector3 itemZero;
    [SerializeField] float speed = 1f;
    [SerializeField] float size = 5f;
    void Start()
    {
        itemZero = gameObject.transform.position;
    }

    void Update()
    {
        gameObject.transform.position = Circle();
    }
    Vector3 Circle() 
    {
        Vector3 circle = new Vector3(itemZero.x + Mathf.Sin(Time.time * speed) * size, itemZero.y + Mathf.Sin(Time.time * speed * 10) * size / 10, itemZero.z);
        return circle;
    }
}
