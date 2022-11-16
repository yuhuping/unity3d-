using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFire : MonoBehaviour
{
    public bool ishitparticle;
    void Start()
    {

        var vfxtime = GetComponent<ParticleSystem>();
        Invoke("setfalse", vfxtime.main.duration);
    }
    public void start()
    {
        var vfxtime = GetComponent<ParticleSystem>();
        Invoke("setfalse", vfxtime.main.duration);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void setfalse()
    {
        if (ishitparticle)
        {
            transform.parent.gameObject.GetComponent<BulletReturnPool>().awake = true;
            transform.parent.gameObject.SetActive(false);
        }
        this.gameObject.SetActive(false);
        
    }
}
