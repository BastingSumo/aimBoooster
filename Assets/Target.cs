using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float timer;
    float DespawnTime;
    Material material;
    [SerializeField] MeshRenderer meshRenderer;

    private void Start()
    {
        DespawnTime = IMLAZY.instance.GetSpawnRate;
    }
    private void Update()
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
