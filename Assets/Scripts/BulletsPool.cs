using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    public static BulletsPool bulletsPoolInstance;      //子弹池单例
    public GameObject bulletObjKind0;                        //子弹perfabs
    public GameObject bulletObjKind1;                        //子弹perfabs
    public int pooledAmount = 5;                        //子弹池初始大小
    public bool lockPoolSize = false;                   //是否锁定子弹池大小

    private List<GameObject> pooledObjectsbullet0;             //第一种子弹池链表
    private List<GameObject> pooledObjectsbullet1;             //第二种子弹池链表
    private int currentIndex = 0;                       //当前指向链表位置索引
    public int currbulletkind = 0;
    void Awake()
    {
        bulletsPoolInstance = this;                     //把本对象作为实例。
    }

    void Start()
    {
        pooledObjectsbullet0 = new List<GameObject>();         //初始化链表
        pooledObjectsbullet1 = new List<GameObject>();         //初始化链表
        for (int i = 0; i < pooledAmount; ++i)
        {
            GameObject obj = Instantiate(bulletObjKind0);    //创建子弹对象
            obj.transform.parent = this.transform;
            obj.SetActive(false);                       //设置子弹无效
            pooledObjectsbullet0.Add(obj);                     //把子弹添加到链表（对象池）中
            GameObject obj1 = Instantiate(bulletObjKind1);
            obj1.transform.parent = this.transform;//创建子弹对象
            obj1.SetActive(false);                       //设置子弹无效
            pooledObjectsbullet1.Add(obj1);                     //把子弹添加到链表（对象池）中
        }
    }

    public GameObject GetPooledObject()                 //获取对象池中可以使用的子弹。
    {
        //第一种子弹
        if (currbulletkind==0)
        {
            for (int i = 0; i < pooledObjectsbullet0.Count; ++i)   //把对象池遍历一遍
            {
                //这里简单优化了一下，每一次遍历都是从上一次被使用的子弹的下一个，而不是每次遍历从0开始。
                //例如上一次获取了第4个子弹，currentIndex就为5，这里从索引5开始遍历，这是一种贪心算法。
                int temI = (currentIndex + i) % pooledObjectsbullet0.Count;
                if (!pooledObjectsbullet0[temI].activeInHierarchy) //判断该子弹是否在场景中激活。
                {
                    currentIndex = (temI + 1) % pooledObjectsbullet0.Count;
                    return pooledObjectsbullet0[temI];             //找到没有被激活的子弹并返回
                }
            }
            //如果遍历完一遍子弹库发现没有可以用的，执行下面
            if (!lockPoolSize)                               //如果没有锁定对象池大小，创建子弹并添加到对象池中。
            {
                GameObject obj = Instantiate(bulletObjKind0);
                pooledObjectsbullet0.Add(obj);
                pooledAmount++;
                return obj;
            }
        }
        //第二种子弹
        if (currbulletkind == 1)
        {
            for (int i = 0; i < pooledObjectsbullet1.Count; ++i)   //把对象池遍历一遍
            {
                //这里简单优化了一下，每一次遍历都是从上一次被使用的子弹的下一个，而不是每次遍历从0开始。
                //例如上一次获取了第4个子弹，currentIndex就为5，这里从索引5开始遍历，这是一种贪心算法。
                int temI = (currentIndex + i) % pooledObjectsbullet1.Count;
                if (!pooledObjectsbullet1[temI].activeInHierarchy) //判断该子弹是否在场景中激活。
                {
                    currentIndex = (temI + 1) % pooledObjectsbullet1.Count;
                    return pooledObjectsbullet1[temI];             //找到没有被激活的子弹并返回
                }
            }
            //如果遍历完一遍子弹库发现没有可以用的，执行下面
            if (!lockPoolSize)                               //如果没有锁定对象池大小，创建子弹并添加到对象池中。
            {
                GameObject obj = Instantiate(bulletObjKind1);
                pooledObjectsbullet1.Add(obj);
                pooledAmount++;
                return obj;
            }
        }
        //如果遍历完没有而且锁定了对象池大小，返回空。
        return null;
    }
    public void ChangeBullet()
    {
        //让GameManagerProp调用更换发射子弹类别
        currbulletkind = 1 - currbulletkind;
    }

}