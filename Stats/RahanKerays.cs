using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RahanKerays : MonoBehaviour
{

    private float rahanarvo;
    public float rahanAlinArvo;
    public float rahanYlinArvo;
    public AudioSource audioSource;
    private void Awake()
    {
        rahanarvo = Mathf.Round(Random.Range(rahanAlinArvo, rahanYlinArvo));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            collision.gameObject.GetComponent<Inventory>().rahansiirto(rahanarvo);
            Destroy(gameObject);
        }
    }
}
