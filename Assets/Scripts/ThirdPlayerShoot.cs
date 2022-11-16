using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPlayerShoot : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public MainItem mainItem;
    [SerializeField] private Transform barrelLocation;


    [SerializeField] private float destroyTimer = 1f;
    [SerializeField] private float shotPower = 10000;//力量

    private Vector3 target;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Item item = mainItem.CurrBullet();
            item.itemNum--;

            Shoot();
        }
            

    }

    void Shoot()
    {
        
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycasthit;
        if (Physics.Raycast(camRay, out raycasthit))//如果射线碰撞到物体
        {
            target = raycasthit.point;//记录碰撞的目标点
            target.y = transform.position.y;
        }
        else//射线没有碰撞到目标点
        {
            //将目标点设置在摄像机自身前方1000米处
            target =transform.forward * 800;

        }
        GameObject bullet = BulletsPool.bulletsPoolInstance.GetPooledObject();//使用对象池的子弹
        if (bullet != null)                  //不为空时执行
        {
            bullet.SetActive(true);         //激活子弹并初始化子弹的位置
            bullet.transform.position = barrelLocation.position;
            bullet.transform.LookAt(target);
        }
    }
}
