using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class FireBallHit : MonoBehaviour
{
    public GameObject boom;
    public GameObject EndPos;
    void Start()
    {
        boom.transform.position = EndPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, EndPos.gameObject.transform.position, 30f*Time.deltaTime);
        float y = this.transform.position.y;
        if (y < 1)
        {
            boom.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("Boom!!!!");
            boom.SetActive(true);

        }
    }
}
