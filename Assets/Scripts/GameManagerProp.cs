using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerProp : MonoBehaviour
{
    private int[] propState;
    public GameObject[] prop;
    private GameObject bagUI;
    public GameObject prop1Prefabs; 
    public GameObject prop3Prefabs;
    public Item item;
    //背包的数据仓库
    public MainItem mainItem;
    private bool selectSomething=false; //判断当前是否选择了某物品
    public GameObject bulletsPool;
    private bool selectfrag=false;//判断是否选择了手雷
    private bool selectFireball = false;//判断是否选择了火球技能
    private GameObject playerhand;
    void Start()
    {
        playerhand = GameObject.FindWithTag("Hand");
         prop = new GameObject[4];

        bagUI = GameObject.Find("Prop");
        propState = new int[10];
        for (int i=0;i<10;i++)
        {
            propState[i] = 0;//初始化所有UI状态
        }
        //下面将prop道具UI对象都获取到放入prop[]中
        prop[0]= GameObject.Find("prop1");
        prop[1] = GameObject.Find("prop2");
        prop[2] = GameObject.Find("prop3");
        prop[3] = GameObject.Find("prop4");

    }

    void Update()
    {
        if (selectSomething)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycasthit;
                Vector3 target=new Vector3(0,0,0);
                if (Physics.Raycast(camRay, out raycasthit))//如果射线碰撞到物体
                {
                    target = raycasthit.point;//记录碰撞的目标点
                    target.y = transform.position.y;
                }
                else
                {
                    Debug.Log("prop");
                }
                Quaternion rotation = Quaternion.Euler(0f, 0f, 0f);
                if (selectfrag)
                {
                    GameObject prop = Instantiate(prop3Prefabs, playerhand.transform.position, rotation);
                }
                else
                {
                    GameObject prop = Instantiate(prop1Prefabs, target, rotation);
                }
                item.itemNum--;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))//使用道具1
        {
            if (propState[0] == 1)
            {
                //propState = 0; selectSomething = false;
                //当前选中子弹进行子弹种类切换
                bulletsPool.GetComponent<BulletsPool>().ChangeBullet();
                propState[0] = 0; selectSomething = false;
            }
            else
            {
                propState[0] = 1; selectSomething = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))//使用道具2
        {
            if (propState[1] == 1)
            {
                //propState = 0; selectSomething = false;
                //当前选中子弹进行子弹种类切换
                //bulletsPool.GetComponent<BulletsPool>().ChangeBullet();
                propState[1] = 0; selectSomething = false;
            }
            else
            {
                propState[1] = 1; selectSomething = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))//使用道具3
        {
            if (propState[2] == 1)
            {
                //propState = 0; selectSomething = false;
                //当前选中子弹进行子弹种类切换
                //bulletsPool.GetComponent<BulletsPool>().ChangeBullet();
                propState[2] = 0; selectSomething = false;selectfrag = false;
            }
            else
            {
                propState[2] = 1; selectSomething = true; selectfrag = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))//使用道具4
        {
            if (propState[3] == 1)
            {
                //propState = 0; selectSomething = false;
                //当前选中子弹进行子弹种类切换
                //bulletsPool.GetComponent<BulletsPool>().ChangeBullet();
                propState[3] = 0; selectSomething = false;
            }
            else
            {
                propState[3] = 1; selectSomething = true;
            }

        }
        ScaleProp();
    }

    void ScaleProp()
    {

        for (int i = 0; i < 4; i++)
        {
            if (propState[i] == 1)
            {
                prop[i].transform.localScale= new Vector3(1.4f, 1.4f, 1.4f);
            }
            else
            {
                prop[i].transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }

}
