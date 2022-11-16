using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private GameObject replacObject;
    [SerializeField] private float breakforces=10;
    [SerializeField] private float forces = 10f;
    private float col = 100;
    private bool broken;

    void OnTriggerEnter(Collider collider)
    {
        if (broken) return;
        if (collider.tag.Equals("bullet"))
        {
            broken = true;
            var replace = Instantiate(replacObject, transform.position, transform.rotation);
            replace.SetActive(true);
            
            foreach (Transform child in replace.transform.GetChild(0).gameObject.transform)
            {
                Debug.Log("a");
                Rigidbody a = child.GetComponent<Rigidbody>();
                a.AddExplosionForce(forces*2, collider.transform.position, 3);

            }
            //foreach (Transform child in replace.transform.GetChild(1).gameObject.transform)
            //{
            //    Debug.Log("dada");
            //    Rigidbody a = child.GetComponent<Rigidbody>();
            //    a.AddExplosionForce(forces, collider.transform.position, 2);

            //}
            this.gameObject.SetActive(false);
        }
    }


    //void OnCollisionEnter(Collision collision)
    //{
    //    if (broken) return;
    //    if (collision.relativeVelocity.magnitude>5f)
    //    {
    //        Debug.Log("breakforces");
    //        broken = true;
    //        var replace = Instantiate(replacObject, transform.position, transform.rotation);
    //        replace.SetActive(true);
    //        foreach (Transform child in replace.transform)
    //        {
    //            Rigidbody a = child.GetComponent<Rigidbody>();
    //            a.AddExplosionForce(forces, collision.contacts[0].point, 2);

    //        }
    //        this.gameObject.SetActive(false);
    //    }
}
        
