using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int XP;
    [SerializeField] int health = 10;
    [SerializeField] GameObject player;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Bullet") 
        {
            Debug.Log("Hit");
            Debug.Log(collision.transform.tag);
        }
        
        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("Enemy hit player");
            LoseHealth();
        }
    }
    public void LoseHealth()
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
