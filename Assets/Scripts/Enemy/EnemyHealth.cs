using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        
        enemyAudio = GetComponent <AudioSource> ();
        if (enemyAudio == null) enemyAudio = gameObject.AddComponent<AudioSource>();

        hitParticles = GetComponentInChildren <ParticleSystem> ();
        
        capsuleCollider = GetComponent <CapsuleCollider> ();
        if (capsuleCollider == null) {
            capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
            capsuleCollider.center = new Vector3(0, 0.8f, 0);
            capsuleCollider.radius = 0.5f;
            capsuleCollider.height = 1.2f;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true; // Quái vật di chuyển bằng AI nên tắt vật lý
        }

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        if (hitParticles != null) {
            hitParticles.transform.position = hitPoint;
            hitParticles.Play();
        }

        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        if (capsuleCollider != null)
            capsuleCollider.isTrigger = true;

        if (anim != null && anim.runtimeAnimatorController != null)
        {
            anim.SetTrigger ("Dead");
        }

        if (enemyAudio != null && deathClip != null)
        {
            enemyAudio.clip = deathClip;
            enemyAudio.Play ();
        }

        // Thay vì đợi Animation báo hiệu, ta tự đếm ngược 2 giây rồi cho chìm xuống đất
        Invoke("StartSinking", 2f);
    }


    public void StartSinking ()
    {
        GetComponent <UnityEngine.AI.NavMeshAgent> ().enabled = false;
        GetComponent <Rigidbody> ().isKinematic = true;
        isSinking = true;
        
        ScoreManager.score += scoreValue;
        
        Destroy (gameObject, 2f);
    }
}
