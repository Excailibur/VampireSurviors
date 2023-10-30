using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Enemy : MonoBehaviour
{
    private Transform player;                           //Player position

    private float speed = 5;

    [SerializeField] private LayerMask playerMask;      //LayerMask to find player

    //Patroling
    //bool walkPointSet;
    //[SerializeField] private float walkPointRange;

    //States
    [SerializeField] public float sightRange;
    [SerializeField] private bool playerInSightRange;
    [SerializeField] private PlayerManager playerInstance;

    private AudioSource source;
    //Find GameObject Components
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //State Controller and time controller
        if (Time.timeScale > 0)
        {
            //Checks for sight
            playerInSightRange = Physics2D.OverlapCircle(transform.position, sightRange, playerMask);

            if (playerInSightRange)
            {
                ChasingPlayer();
            }
        }

    }

    //Chases player
    public void ChasingPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    //Gizmos for seeing attackRange and sightRange
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position,new Vector3(0, 0, 1), sightRange);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(collision.gameObject);
            source.Play();
            Destroy(gameObject);
            
        }
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("enemy hit player");
            playerInstance.LoseHealth(playerInstance.getHealth(), playerInstance);
        }
    }
}
