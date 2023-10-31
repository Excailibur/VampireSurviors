using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int XP;
    [SerializeField] int health = 10;
    [SerializeField] GameObject player;
    [SerializeField] private TextMeshProUGUI lossText;
    // Start is called before the first frame update

    private void Start()
    {
        lossText.gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "Bullet") 
        {
            Debug.Log("Hit");
            Debug.Log(collision.transform.tag);
        }
        
        if (collision.transform.tag == "Enemy")
        {
            
            LoseHealth();
        }
    }
    public void LoseHealth()
    {
        health--;
        if (health <= 0)
        {
            lossText.gameObject.SetActive(true);
            Time.timeScale = 0;
            Destroy(player);
        }
    }
    public int getHealth()
    {
        return health;
    }
    public int getXP()
    { return XP; }
}
