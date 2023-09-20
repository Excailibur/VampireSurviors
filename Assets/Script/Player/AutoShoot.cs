using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;
    public float fireRate = 0.1f; // Shots per second
    private float nextFireTime;


    void Update()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 shootDirection = (Input.mousePosition - transform.position).normalized;
            rb.velocity = shootDirection * projectileSpeed;
        }
        else
        {
            Debug.LogError("Projectile prefab must have a Rigidbody2D component.");
            Destroy(newProjectile);
        }

        yield return new WaitForSeconds(fireRate);
    }
}
