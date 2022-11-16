using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    void Start()
    {
        explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Boom");

            //collider.gameObject.GetComponent<Enemyhealth>().TakeDamage(200);
            explosion.SetActive(true);
            this.gameObject.SetActive(false);

        }


    }
}
