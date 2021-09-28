using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 6;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerUp = false;
    private float powerUpStrength =15;
    public GameObject powerUpIndicator;



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMove = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalMove * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);

      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine( PowerUpCountdownRoutine());
           
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        // to be able to run time outside update we use courotines and key word yield
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
    // add a collision method to detect collision( mostly applicable for changing phsics)
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            // finding the direction to send the enemy
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);

        }
    }
      
  }
