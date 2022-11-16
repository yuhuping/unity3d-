using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCameraRotate : MonoBehaviour
{
    public float rotateSpeed = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.Rotate(0, -rotateSpeed, 0,Space.World);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.Rotate(0, rotateSpeed, 0,Space.World);
        //    //Quaternion targetRotation = Quaternion.Euler(0, 45, 0);
        //    //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 3);
        //    //this.transform.eulerAngles = Vector3.MoveTowards(this.transform.eulerAngles, new Vector3(0, 45, 0), Time.deltaTime* rotateSpeed);
        //}
    }
}
