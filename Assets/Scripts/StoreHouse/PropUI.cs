using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropUI : MonoBehaviour
{
    // 这个脚本挂载到Canvas下的背包UI上，用来判断背包内是否有道具Item并将其显示
    public MainItem mainItem;
    public GameObject[] ItemUI;
    private GameObject item;
    void Start()
    {
        
    }


    void Update()
    {
        int count = Mathf.Max(mainItem.itemList.Count, 4);
        int currcount = Mathf.Min(mainItem.itemList.Count, 4);
        //ItemUI[0].GetComponent<Image>().sprite = mainItem.itemList[0].itemImage;
        //Debug.Log(mainItem.itemList[0].itemName);
        for (int i = 0; i < currcount; i++)//遍历背包的物品
        {
            if (mainItem.itemList[i].itemNum <= 0)
            {
                item = this.transform.GetChild(i).gameObject;
                item.SetActive(false);

            }
            else
            {
                item = this.transform.GetChild(i).gameObject;
                item.GetComponent<Image>().sprite = mainItem.itemList[i].itemImage;
                var text = item.transform.GetChild(1).gameObject.GetComponent<Text>();
                text.text = mainItem.itemList[i].itemNum.ToString();
            }


        }
        for (int i = mainItem.itemList.Count; i <= 4 - mainItem.itemList.Count; i++)
        {
            item = this.transform.GetChild(i).gameObject;
            item.SetActive(false);
        }
    }
}
