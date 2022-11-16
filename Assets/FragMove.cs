using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;

public class FragMove : MonoBehaviour
{
    public LineRenderer line;
    public float time;
    public float ShotSpeed=2;
    public Transform pointA;
    public Transform pointB;
    public Vector3 speed;
    public List<Vector3> list;
    private float dTime = 0;
    void Start()
    {
        
        
    }
    public List<Vector3> getList()
    {
        return this.list;
    }

    void Update()
    {
        //gravity.y= g * (dTime += Time.fixedDeltaTime);
        //transform.position += (speed + gravity) * Time.fixedDeltaTime;
        Vector3 contorollpos = GetBetweenPoint(pointA.position, pointB.position, 0.8f);//用AB中点作为曲线控制点
        contorollpos.y += 5f;
        pointB.position = getMousePos();//获取鼠标位置作为曲线终点
        list = GetBeizerList(pointA.position, contorollpos, pointB.position, 10);
        line.positionCount = list.Count;
        line.SetPositions(list.ToArray());

    }
    public static List<Vector3> GetBeizerList(Vector3 startPoint, Vector3 controlPoint, Vector3 endPoint, int segmentNum)
    {
        List<Vector3> list = new List<Vector3>();
        Vector3[] path = new Vector3[segmentNum + 1];
        path[0] = startPoint;
        list.Add(path[0]);
        for (int i = 1; i <= segmentNum; i++)
        {
            float t = i / (float)segmentNum;
            Vector3 pixel = CalculateCubicBezierPoint(t, startPoint,
                controlPoint, endPoint);
            path[i] = pixel;
            //Debug.Log("第i"+path[i]);
            list.Add(path[i]);
        }

        return list;
    }

    /// <summary>
    /// 根据T值，计算贝塞尔曲线上面相对应的点
    /// </summary>
    /// <param name="t"></param>T值
    /// <param name="p0"></param>起始点
    /// <param name="p1"></param>控制点
    /// <param name="p2"></param>目标点
    /// <returns></returns>根据T值计算出来的贝赛尔曲线点
    private static Vector3 CalculateCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }
    private Vector3 GetBetweenPoint(Vector3 start, Vector3 end, float distance)
    {
        Vector3 normal = (end - start).normalized;
        return normal * distance + start;

    }

    private Vector3 getMousePos()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycasthit;
        Vector3 target = new Vector3(0, 0, 0);
        if (Physics.Raycast(camRay, out raycasthit))//如果射线碰撞到物体
        {
            target = raycasthit.point;//记录碰撞的目标点
            target.y = 5f;
        }
        else
        {

        }
        return target;
    }
}
