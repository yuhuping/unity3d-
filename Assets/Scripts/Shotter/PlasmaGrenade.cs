using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Data.Util.ActiveFields;

public class PlasmaGrenade : MonoBehaviour {
    public Vector3 endpos;
    private GameObject player;
    public List<Vector3> list;
    int i = 1;
    float time;
    float explosiontime;//爆炸时间
    GameObject go;
    GameObject particlesystem;
    GameObject screws_default;
    GameObject shell_default;
    GameObject sphere6_default2;
    GameObject[] enemy;
    float area = 5;
    public int damagePerShot = 500;//伤害
    bool isboom = false;
    bool isGround = false;
    bool moving = true;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindWithTag("GameController");
        list = new List<Vector3>();
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        particlesystem = transform.Find("LightningExplosionGreen").gameObject;
        screws_default = transform.Find("screws_default").gameObject;
        shell_default = transform.Find("shell_default").gameObject;
        sphere6_default2 = transform.Find("sphere6_default2").gameObject;
        list = player.GetComponent<FragMove>().getList();
        for (int i = 0; i < list.Count; i++)
        {

            //Debug.Log("frag" + list[i]);
        }
        transform.position = list[0];
        transform.LookAt(list[list.Count-1]);
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        explosiontime += Time.deltaTime;
        if (isboom == false) {
            if (explosiontime >= 3) {
                screws_default.GetComponent<MeshRenderer>().enabled = false;
                shell_default.GetComponent<MeshRenderer>().enabled = false;
                sphere6_default2.GetComponent<MeshRenderer>().enabled = false;
                particlesystem.SetActive(true);
                isboom = true;
                if (enemy == null)
                {

                }
                else
                {
                    for (int i = 0; i < enemy.Length; i++)
                    {
                        float distance = (transform.position - enemy[i].transform.position).magnitude;

                        //伤害随距离衰减
                        if (distance < area)
                        {
                            enemy[i].gameObject.GetComponent<Enemyhealth>().TakeDamage((1 - distance / area) * damagePerShot);
                        }
                    }
                }
                
                Destroy(this, 1);
            }
        }
        
            if (time > 0.01f&&!isGround&& moving)//如果当前手雷还在空中曲线运动
            {
                time = 0;
                transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, list[i-1],1);
                i++;
            if (i >= list.Count)
            {
                moving = false;
            }

            }
            if (!moving&&!isGround)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
            Vector3 dir = GetBetweenPoint(transform.position, player.transform.position,0.01f);
            transform.position = list[list.Count - 1];
            this.GetComponent<Rigidbody>().velocity = 5f * transform.forward; ;

            isGround = true;
        }
    }
    private Vector3 GetBetweenPoint(Vector3 start, Vector3 end, float distance)
    {
        Vector3 normal = (end - start).normalized;
        return normal * distance + start;

    }
}
