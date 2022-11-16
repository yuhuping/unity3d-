using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MainItem", menuName = "Bag/New MainItem")]
public class MainItem : ScriptableObject
{
    public List<Item> itemList = new List<Item>();

    public void AddBullet(int number)
    {
        for (int i = 0; i < this.itemList.Count; i++)
        {
            if (this.itemList[i].itemName == "bullet")
            {
                this.itemList[i].itemNum += number;
            }
        }
    }
    public Item CurrBullet()
    {
        //for (int i = 0; i < this.itemList.Count; i++)
        //{
        //    if (this.itemList[i].itemName == "bullet")
        //    {
        //        this.itemList[i].itemNum += 0;
        //    }
        //}
        return this.itemList[0];
    }
}

