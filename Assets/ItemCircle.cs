using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCircle : MonoBehaviour
{
    [SerializeField] Vector3 itemZero;
    [SerializeField] float speed = 1f;
    [SerializeField] float circleSize = 5f;
    void Start()
    {
        itemZero = gameObject.transform.position;
        if(Random.Range(0, 100) > 50)
        {
            speed -= speed + speed;
        }   
    }

    void Update()
    {
        gameObject.transform.position = Circle();

    }
    Vector3 Circle()
    {
        Vector3 circle = new Vector3(itemZero.x + Mathf.Sin(Time.time * speed) * circleSize, itemZero.y + Mathf.Cos(Time.time * speed) * circleSize, itemZero.z);
        return circle;
    }
}
