using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBeHurt : MonoBehaviour
{
    public GameObject blood;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("hurt");
            GameObject shell = GameObject.Instantiate(blood, collision.transform.position, collision.transform.rotation) as GameObject;
            Destroy(shell, 2f);
        }
    }

}
