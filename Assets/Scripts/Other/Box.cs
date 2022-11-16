using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Item item;
    //背包的数据仓库
    public MainItem mainItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider co)
    {

        if (co.gameObject.CompareTag("GameController"))
        {
            Debug.Log("you get something");
            item.itemNum++;
            Destroy(this, 1f);
            this.gameObject.SetActive(false);
        }
        
    }
}
