using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    bool isDead;
    bool damaged;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        
        playerAudio = GetComponent <AudioSource> ();
        if (playerAudio == null) playerAudio = gameObject.AddComponent<AudioSource>();
        
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged && damageImage != null)
        {
            damageImage.color = flashColour;
        }
        else if(damageImage != null)
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        if (healthSlider != null)
            healthSlider.value = currentHealth;

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        if (playerShooting != null)
            playerShooting.DisableEffects ();

        if (anim != null && anim.runtimeAnimatorController != null)
            anim.SetTrigger ("Die");

        if (deathClip != null)
        {
            playerAudio.clip = deathClip;
            playerAudio.Play ();
        }

        if (playerMovement != null)
            playerMovement.enabled = false;
        if (playerShooting != null)
            playerShooting.enabled = false;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
