using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int XP;
    [SerializeField] int health = 10;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (health<= 0)
        {
            //make a game over scene
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Bullet") 
        {
            Debug.Log(collision.transform.tag);
        }
        
        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("Enemy hit player");
            health--;
        }
    }
    public void LoseHealth(int health,PlayerManager player)
    {
        health--;
        if (health <= 0)
        {
            //make a game over scene
            Destroy(player);
        }
    }
    public int getHealth()
    {
        return health;
    }
}
