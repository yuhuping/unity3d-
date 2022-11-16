
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceBullet : MonoBehaviour {
    private Vector3 target; //瞄准的目标
    Vector3 speed = new Vector3(0, 0, 10); //炮弹本地坐标速度
    //Vector3 speed ; //炮弹本地坐标速度
    Vector3 lastSpeed; //存储转向前炮弹的本地坐标速度
    int rotateSpeed = 270; //旋转的速度，单位 度/秒
    Vector3 finalForward; //目标到自身连线的向量，最终朝向
    float angleOffset;  //自己的forward朝向和mFinalForward之间的夹角
    RaycastHit hit;
    public GameObject[] enemy;//敌人
    int now = 0;//当前敌人索引

    private GameObject ifinite;
    void Start() {
        //将炮弹的本地坐标速度转换为世界坐标
        //speed = transform.TransformDirection(Camera.main.transform.forward * 800);
        speed = transform.TransformDirection(speed);
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update() {
        if(now < enemy.Length) {
            if (enemy[now].gameObject.GetComponent<Enemyhealth>().hp >= 0) {
                target = enemy[now].gameObject.transform.position;
            } else {
                now++;
            }
        }
        
        else{
            //无敌人时当前目标为远处
            //target = Camera.main.transform.forward * 800;
            return;
        }
        CheckHint();
        UpdateRotation();
        UpdatePosition();
    }

    //射线检测，如果击中目标点则销毁炮弹
    void CheckHint() {
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            if (hit.transform.position == target && hit.distance < 1) {
                Destroy(gameObject);
            }
        }
    }

    //更新位置
    void UpdatePosition() {
        transform.position = transform.position + speed * Time.deltaTime;
    }

    //旋转，使其朝向目标点，要改变速度的方向
    void UpdateRotation() {
        //先将速度转为本地坐标，旋转之后再变为世界坐标
        lastSpeed = transform.InverseTransformDirection(speed);

        ChangeForward(rotateSpeed * Time.deltaTime);

        speed = transform.TransformDirection(lastSpeed);
    }

    void ChangeForward(float speed) {
        //获得目标点到自身的朝向
            finalForward = (target- transform.position).normalized;
            if (finalForward != transform.forward) {
                angleOffset = Vector3.Angle(transform.forward, finalForward);
                if (angleOffset > rotateSpeed) {
                    angleOffset = rotateSpeed;
                }
                //将自身forward朝向慢慢转向最终朝向
                transform.forward = Vector3.Lerp(transform.forward, finalForward, speed / angleOffset);
            }
      

    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<Enemyhealth>().TakeDamage(50);
            Destroy(this);

        }
        if (collision.gameObject.tag == "Enemybaoji") {
            collision.gameObject.GetComponentInParent<Enemyhealth>().TakeDamage(100);
            Destroy(this);

        }
    }
    

}
