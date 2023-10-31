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
    [SerializeField] private TextMeshProUGUI HealthText;
    // Start is called before the first frame update

    private void Start()
    {
        lossText.gameObject.SetActive(false);
        HealthText.text = "Health: " + health.ToString();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            StopCoroutine("Damage");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            StartCoroutine("Damage");
        }
    }

    public void LoseHealth()
    {
        health--;
        setHealth();
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

    private void setHealth()
    {
        HealthText.text = "Health: " + health.ToString();
    }
    IEnumerator Damage()
    {
        while (true)
        {
            LoseHealth();
            yield return new WaitForSeconds(1.5f);
        }
    }
}
