using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddbulletProp : MonoBehaviour
{
    public Item item;
    //背包的数据仓库
    public MainItem mainItem;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(this.transform.position, player.transform.position));
        if (Vector3.Distance(this.transform.position, player.transform.position) < 1.3f)
        {
            Debug.Log("you get something");
            //item.itemNum++;
            mainItem.AddBullet(2);
            Destroy(this, 1f);
            this.gameObject.SetActive(false);
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("GameController"))
    //    {
    //        Debug.Log("you get something");
    //        item.itemNum++;
    //        Destroy(this, 1f);
    //        this.gameObject.SetActive(false);
    //    }

    //}
}
