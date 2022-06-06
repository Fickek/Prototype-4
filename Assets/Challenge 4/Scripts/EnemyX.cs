using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private SpawnManagerX speedCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
        speedCount = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
        
    }

    // Update is called once per frame
    void Update()
    {
        int speed = speedCount.waveCount - 1;
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * (speed * 30) * Time.deltaTime);
        Debug.Log(speed * 30);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If enemy collides with either goal, destroy it
        if (collision.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (collision.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
