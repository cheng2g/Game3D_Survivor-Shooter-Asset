using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public float camRayLength = 100f; 
    public int floorMask = -1; 

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;


    void Awake ()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
        
        // Tự động thêm các component nếu chưa có để giúp người mới dễ làm hơn
        gunParticles = GetComponent<ParticleSystem>();
        // Bỏ dòng tự động tạo ParticleSystem để tránh ra khối hồng (vì thiếu hình ảnh tia lửa)

        gunLine = GetComponent<LineRenderer>();
        if (gunLine == null) {
            gunLine = gameObject.AddComponent<LineRenderer>();
            gunLine.startWidth = 0.05f;
            gunLine.endWidth = 0.05f;
            gunLine.material = new Material(Shader.Find("Sprites/Default"));
            gunLine.startColor = Color.yellow;
            gunLine.endColor = Color.yellow;
        }

        gunAudio = GetComponent<AudioSource>();
        if (gunAudio == null) {
            gunAudio = gameObject.AddComponent<AudioSource>();
            gunAudio.playOnAwake = false;
        }

        gunLight = GetComponent<Light>();
        if (gunLight == null) {
            gunLight = gameObject.AddComponent<Light>();
            gunLight.color = Color.yellow;
            gunLight.range = 5f;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot ();
        }

        if(timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects ();
        }
    }


    public void DisableEffects ()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        if (gunParticles != null)
        {
            gunParticles.Stop();
            gunParticles.Play();
        }

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        // Tính toán hướng bắn theo chuột
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        Vector3 shootDirection = transform.forward; // Mặc định bắn theo hướng player

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            shootDirection = (floorHit.point - transform.position).normalized;
        }

        shootRay.origin = transform.position;
        shootRay.direction = shootDirection; // Bắn theo hướng chuột

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
