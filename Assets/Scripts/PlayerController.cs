using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    private float powerupStrength = 15.0f;
    public float speed = 5f;
    public bool hasPowerup = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        
    }

    // Update is called once per frame
    void Update()
    {  
        float forwardInput = Input.GetAxis("Vertical");
        playerRigidBody.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(CountPowerupRoutine());
            powerupIndicator.SetActive(true);
        }
    }

    IEnumerator CountPowerupRoutine() 
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromEnemy = collision.gameObject.transform.position - transform.position;

            enemyRigidBody.AddForce(awayFromEnemy * powerupStrength, ForceMode.Impulse);

            Debug.Log("Collied with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}
