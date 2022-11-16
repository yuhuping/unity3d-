using UnityEngine;

public class ShootLight : MonoBehaviour {
    public int damagePerShot = 30;//伤害
    public float timeBetweenBullets = 0.15f;//影响射速
    public float range = 100f;//最远距离


    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer lineRenderer;//linerenderer组件
    AudioSource gunAudio;
    Light light;//light组件
    float effectsDisplayTime = 0.2f;


    void Awake() {
        //shootableMask = LayerMask.GetMask("Shootable");
        //gunParticles = GetComponent<ParticleSystem>();
        lineRenderer = GetComponent<LineRenderer>();
        //gunAudio = GetComponent<AudioSource>();
        light = GetComponent<Light>();
    }


    void Update() {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0) {
            Shoot();
        }

        //不开枪时关闭灯光效果
        if (timer >= timeBetweenBullets * effectsDisplayTime) {
            Debug.Log("DisableEffects");
            DisableEffects();
        }
    }


    public void DisableEffects() {
        lineRenderer.enabled = false;
        light.enabled = false;
    }


    void Shoot() {
        timer = 0f;

        //开枪音效
        //gunAudio.Play();

        light.enabled = true;

        //枪管特效
        //gunParticles.Stop();
        //gunParticles.Play();

        lineRenderer.enabled = true;
        Debug.Log("lineRenderer.enabled = true");
        lineRenderer.SetPosition(0, transform.position);


        shootRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(shootRay, out shootHit))//如果射线碰撞到物体
        {
            Enemyhealth enemyhealth = shootHit.collider.GetComponent<Enemyhealth>();
            if (enemyhealth != null) {
                enemyhealth.TakeDamage(damagePerShot);
            }
            lineRenderer.SetPosition(1, shootHit.point);

        } else//射线没有碰撞到目标点
          {
            lineRenderer.SetPosition(1, shootRay.origin + shootRay.direction * range);

        }

    }
}
