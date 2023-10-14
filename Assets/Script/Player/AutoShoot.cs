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
                Vector3 shootDirection = (pos - transform.position).normalized;
                float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
                if (angle < 0) { angle += 360; }
                newProjectile.transform.eulerAngles = new Vector3(0, 0, angle);
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
