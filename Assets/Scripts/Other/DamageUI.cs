using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUI : MonoBehaviour
{
    

    //public Rigidbody2D rb;
    public float liftime = 1f;
    public float minDist = 2f;
    public float maxDist = 3f;
    public Text tt;
    
    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;
    void Start()
    {

        
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        float direction = Random.rotation.eulerAngles.x;
        
        iniPos = transform.position;
        float dist = Random.Range(minDist, maxDist);
        
        targetPos = iniPos + (Quaternion.Euler(0, 0, direction) * new Vector3(dist, dist, 0f));

    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / liftime));

        if (timer > liftime) Destroy(gameObject);
    }
    public void SetDamageText(float damage)
    {
        tt.text = damage.ToString();
       
    }
    
}
