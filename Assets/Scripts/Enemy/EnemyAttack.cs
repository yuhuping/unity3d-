using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private GameObject player;
    public int damage = 20;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameController");
        if(!player)player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("GameController"))
        {
            Debug.Log("PlayerHurt");
            player.GetComponent<PlayerHealth>().PlayerBehurt(damage);

        }
    }
}
