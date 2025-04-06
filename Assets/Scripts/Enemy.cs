using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public float harderEnemySpeed = 1f;
    private Rigidbody enemyRigidBody;
    private SpawnManager spawnManagerScript;
    private GameObject player;
    private Rigidbody playerRigidBody;
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerRigidBody = GameObject.Find("Player").GetComponent<Rigidbody>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRigidBody.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        if (spawnManagerScript.waveNumber == 2)
        {
            CreateHarderEnemy();
        }
    }

    public void CreateHarderEnemy() 
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRigidBody.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }
}
