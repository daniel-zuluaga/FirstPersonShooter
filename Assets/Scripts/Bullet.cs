using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;

    private void OnEnable()
    {
        shootTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // did we hit the player?
        if (other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        else if (other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);
        // disable the bullet
        gameObject.SetActive(false);
    }

}
