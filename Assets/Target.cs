using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float timer;
    float DespawnTime;
    Material material;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] bool test = false;

    private void Start()
    {
        if (!test) DespawnTime = IMLAZY.instance.GetSpawnRate;
        else DespawnTime = 1000;
    }
    private void Update()
    {
        if (!test)
        {
            timer += 1 * Time.deltaTime;
            if (timer >= 3)
            {
                IMLAZY.instance.audioSource.PlayOneShot(IMLAZY.instance.bad);
                IMLAZY.instance.lives--;
                Destroy(gameObject);
            }
            Color temp = Color.green;
            temp.r += timer;
            meshRenderer.materials[0].color = temp;
            gameObject.transform.Rotate(Vector3.up, 1);
        }

    }
}
