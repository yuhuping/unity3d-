using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    private GameObject cam;
    private float horizontal;
    private float vertical;
    
    //定义一个重力gravity 
    private float gravity = 9.8f;
    //定义一个起跳速度
    public float JumpSpeed = 5f;
    //用于实例化对象
    public CharacterController PlayerController;

    Vector3 Player_Move;
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("ThirdCamera");

    }
    void Update()
    {
        if (!cam) 
        {
            Debug.Log("no gameobject with tag(ThirdCamera)");
            return;
        }
        RotateToMousePos();
        //判断PlayerController是否在地面上，如果不是在地面上就不能够前后左右移动，也不能够起跳
        if (PlayerController.isGrounded)
        {
            //Input.GetAxis("Horizontal")为获取X(横轴)轴方向的值给horizontal
            horizontal = Input.GetAxis("Horizontal");
            //Input.GetAxis("Vertical")为获取Z(纵轴)轴方向的值给Vertical
            vertical = Input.GetAxis("Vertical");

            Vector3 forward = cam.transform.forward;
            forward.y = 0;//将摄影机前方向量投影到xoz平面
            Player_Move = (forward * vertical*2 + cam.transform.right * horizontal) * MoveSpeed;

            //判断玩家是否按下空格键
            if (Input.GetAxis("Jump") == 1)
            {
                Player_Move.y = Player_Move.y + JumpSpeed;
            }
        }

        Player_Move.y = Player_Move.y - gravity * Time.deltaTime;

        //PlayerController下的.Move为实现物体运动的函数
        //Move()括号内放入一个Vector3类型的量，本例中为Player_Move
        PlayerController.Move(Player_Move * Time.deltaTime);
    }
    void RotateToMousePos()
    {
        var r = GetAimPos();
        transform.LookAt(r + transform.position);

    }
    public Vector3 GetAimPos()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, 100f, LayerMask.GetMask("Floor")))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;
            return playerToMouse;
        }
        return Vector3.zero;
    }
}
