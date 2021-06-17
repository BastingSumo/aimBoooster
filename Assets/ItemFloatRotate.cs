using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFloatRotate : MonoBehaviour
{
    public float BobRate = 1.0f;
    public float BobSize = 0.6f;
    private float BobTick = 0.0f;
    private float yOrigin;
    bool OtherWay = false;
    [SerializeField] bool Ybob = false;
    private void Awake()
    {
        float random = Random.Range(0, 100);
        if (random > 50) OtherWay = true;
    }
    private void Start()
    {
        yOrigin = gameObject.transform.position.y;
    }
    private void Update()
    {
        BobRate = IMLAZY.targetMoveSpeed;
        BobTick += BobRate * Time.deltaTime;
        float SinValue = Mathf.Sin(BobTick);

        float newYPosition = yOrigin + BobSize * SinValue;

        if (Ybob)
        {
            if (OtherWay) gameObject.transform.position = new Vector3(gameObject.transform.position.x, newYPosition, gameObject.transform.position.z);
            else gameObject.transform.position = new Vector3(gameObject.transform.position.x, -newYPosition, gameObject.transform.position.z);
        }
        else
        {
            if (OtherWay) gameObject.transform.position = new Vector3(newYPosition, gameObject.transform.position.y, gameObject.transform.position.z);
            else gameObject.transform.position = new Vector3(-newYPosition, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }
}
