using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureEight : MonoBehaviour
{
    [SerializeField] Vector3 itemZero;
    [SerializeField] float speed = 1f;
    [SerializeField] float size = 5f;
    [SerializeField] bool flip = false;
    void Start()
    {
        itemZero = gameObject.transform.position;
        flip = Random.Range(0, 100) > 50;
    }

    void Update()
    {
        if (flip) gameObject.transform.position = Circle(speed, speed / 2);
        else gameObject.transform.position = Circle(speed, -speed / 2);

    }
    Vector3 Circle(float xSpeed, float ySpeed)
    {
        Vector3 circle = new Vector3(itemZero.x + Mathf.Sin(Time.time * xSpeed) * size, itemZero.y + Mathf.Sin(Time.time * ySpeed) * size, itemZero.z);
        return circle;
    }
}
