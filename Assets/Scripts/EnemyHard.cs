using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHard : MonoBehaviour
{

    private Rigidbody enemyHardRg;
    public GameObject player;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyHardRg = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyHardRg.AddForce(lookDirection * speed);
        //Debug.Log(player.transform.position);
        //Debug.Log(transform.position);
        


        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Rigidbody enemyRg = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log(collision.gameObject.transform.position - transform.position);
            //enemyHardRg.AddForce(awayFromPlayer * 30, ForceMode.Impulse);
        }
        
    }
}
