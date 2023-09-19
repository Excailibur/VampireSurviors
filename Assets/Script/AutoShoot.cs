using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;
    public float fireRate = 0.5f; // Shots per second
    private float nextFireTime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Debug.Log("Enemy_Spotted");

            if (Time.time >= nextFireTime)
            {
                nextFireTime = Time.time + 1f / fireRate;
                Shoot(collision.transform.position);
            }
        }
    }

    void Shoot(Vector3 targetPosition)
    {
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 shootDirection = (targetPosition - transform.position).normalized;
            rb.velocity = shootDirection * projectileSpeed;
        }
        else
        {
            Debug.LogError("Projectile prefab must have a Rigidbody2D component.");
            Destroy(newProjectile);
        }
    }
}
