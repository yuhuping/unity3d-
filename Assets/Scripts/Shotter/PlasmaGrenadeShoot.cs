using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlasmaGrenadeShoot : MonoBehaviour
{
    public LineRenderer line;
    public Transform ball;//抛物线末尾的球
    public float t;//每隔多久计算抛物线上的点
    public float speed;//初速度

    public GameObject plasmagrenade;//手雷预设
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {//按下左键绘制抛物线
            ball.gameObject.SetActive(true);
            line.gameObject.SetActive(true);
            List<Vector3> list = GetVector3s();
            line.positionCount = list.Count;
            line.SetPositions(list.ToArray());
            ball.position = list[list.Count - 1];

        }
        if (Input.GetMouseButtonUp(1))
        {
            line.gameObject.SetActive(false);
            ball.gameObject.SetActive(false);
            GameObject plasmaGrenade = Instantiate(plasmagrenade, transform.position, transform.rotation);
            plasmaGrenade.GetComponent<Rigidbody>().velocity = speed * transform.forward;//发射方向
            //plasmaGrenade.GetComponent<ParticleSystem>().Play();
        }

    }


    List<Vector3> GetVector3s()
    {
        List<Vector3> list = new List<Vector3>();
        //前方的水平向量
        Vector3 horizonDir = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
        float angle = 360 - transform.rotation.eulerAngles.x;//前方与水平向量的夹角
        float horizontalSpeed = Mathf.Cos(angle / 180 * Mathf.PI) * speed;//水平方向速度
        float verticalSpeed = Mathf.Sin(angle / 180 * Mathf.PI) * speed;//垂直方向速度
        for (int i = 0; i < 1000; i++)//点数量上限为1000个
        {

            //点位置为初始位置加速度乘以时间间隔，方向向上
            Vector3 position = transform.position + (horizontalSpeed * t * i * horizonDir) + ((verticalSpeed + (verticalSpeed + Physics.gravity.y * t * i)) / 2 * t * i * transform.up);

            //添加坐标点
            list.Add(position);

            //如果没有绘制完1000个点就撞到墙
            if (i > 0)//点大于两个，用于计算末尾方向rearDir
            {
                RaycastHit hit;
                Vector3 rearDir = list[list.Count - 1] - list[list.Count - 2];//最后一段被障碍物挡住的线段方向
                if (Physics.Raycast(list[list.Count - 2], rearDir, out hit, rearDir.magnitude))//
                {
                    list[list.Count - 1] = hit.point; //最后一个点设为射线碰撞点
                    break;//结束
                }
            }
        }
        return list;//返回列表
    }
    
}