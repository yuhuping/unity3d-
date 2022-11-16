using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bullet : MonoBehaviour
{
    public AudioClip hurtLifeaudio;
    private AudioSource audio;
    private bool die;//子弹已经触发用过了
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collision)
    {
        if (die) return;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("EnemyBehurt");
            audio.clip = hurtLifeaudio;
            audio.Play();
            collision.gameObject.GetComponent<Enemyhealth>().TakeDamage(50);
            die = true;
            Destroy(this,2f);

        }
        if (collision.gameObject.CompareTag("Enemybaoji"))
        {
            collision.gameObject.GetComponentInParent<Enemyhealth>().TakeDamage(100);
            die = true;
            Destroy(this);
        }
        

        
    }
}
