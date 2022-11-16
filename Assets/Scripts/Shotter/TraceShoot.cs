
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceShoot : MonoBehaviour {
    public GameObject missile; // 子弹
    float timer;
    public float timeBetweenBullets = 0.15f;//影响射速
    private void Start() {
    }
    void Update() {
        timer += Time.deltaTime;


        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0) {
            Shoot();
        }

    }

    void Shoot() {
        timer = 0f;
        GameObject m = GameObject.Instantiate(missile, transform.position /*+ transform.up*/, transform.rotation);
        m.SetActive(true);
        Destroy(m, 2);
    }
}
