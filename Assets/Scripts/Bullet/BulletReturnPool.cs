using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletReturnPool : MonoBehaviour
{
    public bool awake=false;
    private AudioClip hitaudioClip;
    private AudioClip muzzleaudioClip;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (awake)
        {
            transform.GetChild(0).gameObject.transform.position = transform.position;
            transform.GetChild(0).gameObject.SetActive(true);

            transform.GetChild(0).gameObject.GetComponent<BulletMove>().isover=true;
            awake = false;
        }
    }
    void setfalse()
    {
        awake = true;
        this.gameObject.SetActive(false);

    }
}
