using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public GameObject projectilePrefab;

    [SerializeField] private Transform CrossHairImage;

    public float projectileSpeed = 10.0f;
    public float fireRate = 0.01f; // Shots per second
    private float nextFireTime;


    void Start()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Debug.Log(Input.mousePosition);
                Vector3 shootDirection = (pos - transform.position).normalized;
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
}
