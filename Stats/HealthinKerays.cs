using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthinKerays : MonoBehaviour
{

    private float HealingAmount;
    public AudioSource audioSource;
    private void Awake()
    {
        HealingAmount = Mathf.Round(Random.Range(10f, 25f));
    }
    private void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            collision.gameObject.GetComponent<PlayerHealth>().IncreaseHP(HealingAmount);
            Destroy(gameObject);
           // audioSource.gameObject.SetActive(false);
        }
    }
}
