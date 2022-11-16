using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SimpleShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    /// <summary>
    /// 枪管位置
    /// </summary>
    [SerializeField] private Transform barrelLocation;


    [SerializeField] private float destroyTimer = 1f;
    [SerializeField] private float shotPower = 10000;//力量

    private Vector3 target;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
        //if (gunAnimator == null)
        //    gunAnimator = GetComponentInChildren<Animator>();
        
        
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            Shoot();

    }
    void FixedUpdate()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit raycasthit;
        if (Physics.Raycast(ray, out raycasthit, 800, 1 << LayerMask.NameToLayer("outline")))//如果射线碰撞到物体.只检测第一个碰撞对象
        {
            
        }

    } 
        void Shoot()
    {
      
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit raycasthit;
        if (Physics.Raycast(ray, out raycasthit))//如果射线碰撞到物体
        {
            target = raycasthit.point;//记录碰撞的目标点

        }
        else//射线没有碰撞到目标点
        {
            //将目标点设置在摄像机自身前方1000米处
            target = Camera.main.transform.forward * 800;
            
        }
        GameObject go = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        go.transform.LookAt(target);
        //go.GetComponent<AudioSource>().Play();
        //go.GetComponent<Rigidbody>().AddForce(go.transform.forward * shotPower);
        Destroy(go, 2f);
    }


}
