using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public GameObject muzzle;
    public GameObject hitPrefab;
    
    private bool die;//子弹已经触发用过了
    public bool isover = false;
    void Start()
    {
        if (!muzzle) return;
        muzzle = this.gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject;

        muzzle.SetActive(true);
        hitPrefab = this.gameObject.transform.parent.gameObject.transform.GetChild(2).gameObject;
        hitPrefab.transform.parent = this.gameObject.transform.parent;


        
    }
    public void start()
    {
        muzzle = this.gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject;
        muzzle.transform.position = transform.position;
        muzzle.SetActive(true);
        speed = 30;
        
    }

    void Update()
    {
        if(isover)
        {
            start();
            isover = false;
        }

        if (hitPrefab!=null)
        hitPrefab.transform.position = transform.position;
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        

    }
    //void OnCollisionEnter(Collision co)
    //{
        
        
    //    Debug.Log("collision"+co.gameObject.tag);
    //    speed = 0;
    //    if (die) return;
    //    if (co.gameObject.CompareTag("Enemy"))
    //    {
    //        Debug.Log("EnemyBehurt");

    //        co.gameObject.GetComponent<Enemyhealth>().TakeDamage(50);
    //        die = true;
    //        Destroy(this, 2f);

    //    }
    //    if (co.gameObject.CompareTag("Enemybaoji"))
    //    {
    //        co.gameObject.GetComponentInParent<Enemyhealth>().TakeDamage(100);
    //        die = true;
    //        Destroy(this);
    //    }
    //    if (muzzle != null)//如果有枪口火焰特效
    //    {
    //        var hitvfx = Instantiate(muzzle, transform.position, Quaternion.identity);
    //        hitvfx.transform.forward = gameObject.transform.forward;
    //    }
    //}
    void OnTriggerEnter(Collider co)
    {
        if (co.gameObject.CompareTag("Bulletparticle")|| co.gameObject.CompareTag("GameController"))//如果是与子弹相碰直接返回
            return;
        speed = 0;

        if (co.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("EnemyBehurt");

            co.gameObject.GetComponent<Enemyhealth>().TakeDamage(50);

            this.gameObject.SetActive(false);

        }
        //if (co.gameObject.CompareTag("Enemybaoji"))
        //{
        //    co.gameObject.GetComponentInParent<Enemyhealth>().TakeDamage(100);
        //    die = true;
        //    Destroy(this);
        //}
        if (hitPrefab != null)//如果有打击火焰特效
        {
            die = true;
            hitPrefab.SetActive(true);
            hitPrefab.GetComponent<MuzzleFire>().start();
        }

        this.gameObject.SetActive(false);
    }
}
