using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private bool die;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (die)
        {
            Invoke("setfalse",1f);
        }
    }
    void OnTriggerEnter(Collider co)
    {
        //if (die) return;
        if (co.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("BarrelBoom!");

            co.gameObject.GetComponent<Enemyhealth>().TakeDamage(500);
            
            
            Destroy(this, 2f);
        }
        die = true;
    }
    void setfalse()
    {
        this.gameObject.transform.parent.parent.gameObject.SetActive(false);
    }
}
