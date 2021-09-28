using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private GameObject Player;
    private Rigidbody enemyRb;
   
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawn an enemy
        

        // follow the player , (substract player distance and that of the enemy)

        enemyRb.AddForce((Player.transform.position - transform.position).normalized* speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
