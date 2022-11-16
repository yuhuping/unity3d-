using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Enemyhealth : MonoBehaviour
{
    public float hp = 1000;
    public GameObject damageuiPrefabs;
    private float DefenseValue=20;// 这个enemy对象的防御值
    private GameObject player;
    private Animator animator;
    private bool die=false;
    private Transform hitnbox;
    private Collider collider;
    private AnimatorStateInfo animatorStateInfo;//当前播放动画
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("GameController");
        animator = GetComponent<Animator>();
        
        hitnbox = this.transform.Find("hitbox");
        collider = hitnbox.GetComponent<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;
        if (hp <= 0&&!die)
        {
            die = true;
            animator.SetTrigger("Die");
            Destroy(this.gameObject, 1f);
        }
        else//如果没死执行enemyAI
        {
            AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);//当前播放动画
            bool moving = animatorStateInfo.IsName("walk");
            if (Vector3.Distance(transform.position, player.transform.position) < 1.7f&&animatorStateInfo.IsName("walk"))//如果距离达到要求且没有在攻击状态
            {
                //Debug.Log("canAttack");
                animator.SetTrigger("Attack");
            }
            if (moving)
            {
                MoveTo();
            }
        }

    }

    public void TakeDamage(float damage)
    {
        animator.SetTrigger("Behurt");
        damage = damage - DefenseValue;
        hp -= damage;
        GameObject damageUI = Instantiate(damageuiPrefabs, transform.position, Quaternion.identity)as GameObject;
        damageUI.GetComponent<DamageUI>().SetDamageText(damage);
        //Invoke("SetPos",1f);
    }

    void MoveTo()
    {
        //transform.Translate(player.transform.position.x,transform.position.y,player.transform.position.z);
        transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.5f*Time.deltaTime);
        transform.LookAt(player.transform);
    }
    void ToAttack()
    {

        collider.enabled = true;//将子对象组件的hitbox的状态激活
    }
    void AttackOver()
    {
        collider.enabled = false;
    }
}
