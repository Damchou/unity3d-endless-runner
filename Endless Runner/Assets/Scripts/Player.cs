using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rb;
    public Transform deathZone;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public Transform bumpCheck;
    public Vector2 bumpCheckRadius;
    //public LayerMask whatIsBump;
    private bool onGround;
    private bool onBump;
    private bool doubleJump;
    private bool isGameOver;

    private AudioSource expSound;

    public float jumpHeight;
    public float speed;
    public float timer;
    public ParticleSystem deathParticle1;
    public ParticleSystem deathParticle2;
    public ParticleSystem deathParticle3;
    public ParticleSystem deathParticle4;
    public ParticleSystem deathParticle5;
    public ParticleSystem deathParticle6;
    public ParticleSystem deathParticle7;
    public ParticleSystem deathParticle8;
    public ParticleSystem deathParticle9;


    // FOR TESTING ONLY
    public SpriteRenderer sr;


    public LevelGenerator generator;
    public Highscore score;
    public PlayerController pc;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        expSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if(isGameOver && timer >= 3)
        {
            EndRound();
        }

        // Check if still alive
        if(!isGameOver)
        {
            score.Scoring();
        }

        // Check if on ground
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        onBump = Physics2D.OverlapBox(bumpCheck.position, bumpCheckRadius, 0.0f, whatIsGround);

        CheckBump();

        CheckAirAnimation();

        // Enable jump/doublejump when "Space" is pressed and car is on ground
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && ( onGround || doubleJump))
        {

            Debug.Log("Space pressed");
            if (onGround)
            {
                Debug.Log("on ground = doublejump is true");
                doubleJump = true;
            } else
            {
                Debug.Log("not on ground = doublejump is false");
                doubleJump = false;
            }

            // Jump velocity
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        // Constant forward velocity
        rb.velocity = new Vector2(speed, rb.velocity.y);
        deathZone.position = new Vector3(rb.position.x, -4, 0);

	}

    // Death-collision function
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the car is in contact with something deadly
        if (collision.gameObject.tag == "Enemy")
        {
            Death();
        }
    }

    // Ending (resetting) current round
    private void EndRound()
    {
        pc.StopDeathAnimation();
        StopParticles();
        rb.transform.position = new Vector2(-2, 2.1f);

        // Regenerate some tiles to land on when starting over
        Debug.Log("RENEGERATE AT PLAYER");
        generator.DestroyAll();
        generator.Regenerate();
        doubleJump = true;
        isGameOver = false;
        speed = 8.0f;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        score.resetScore();
    }

    private void CheckBump()
    {
        if(onBump)
            Death();
    }

    private void Death()
    {
        if (!isGameOver) {
            expSound.Play();
            pc.PlayDeathAnimation();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            timer = 0;
            Debug.Log("dead");
            PlayParticles();
            isGameOver = true;
            speed = 0.0f;
        }
    }


    private void CheckAirAnimation()
    {
        // plays ground/air animation depending onGround
        if (!onGround)
        {
            pc.PlayAirAnimation();
        }
        else
        {
            pc.StopAirAnimation();
        }
    }






    private void PlayParticles()
    {
        ParticleSystem.EmissionModule em1 = deathParticle1.emission;
        ParticleSystem.EmissionModule em2 = deathParticle2.emission;
        ParticleSystem.EmissionModule em3 = deathParticle3.emission;
        ParticleSystem.EmissionModule em4 = deathParticle4.emission;
        ParticleSystem.EmissionModule em5 = deathParticle5.emission;
        ParticleSystem.EmissionModule em6 = deathParticle6.emission;
        ParticleSystem.EmissionModule em7 = deathParticle7.emission;
        ParticleSystem.EmissionModule em8 = deathParticle8.emission;
        ParticleSystem.EmissionModule em9 = deathParticle9.emission;

        em1.enabled = true;
        em2.enabled = true;
        em3.enabled = true;
        em4.enabled = true;
        em5.enabled = true;
        em6.enabled = true;
        em7.enabled = true;
        em8.enabled = true;
        em9.enabled = true;

        deathParticle1.Play();
        deathParticle2.Play();
        deathParticle3.Play();
        deathParticle4.Play();
        deathParticle5.Play();
        deathParticle6.Play();
        deathParticle7.Play();
        deathParticle8.Play();
        deathParticle9.Play();
    }

    private void StopParticles()
    {

        ParticleSystem.EmissionModule em1 = deathParticle1.emission;
        ParticleSystem.EmissionModule em2 = deathParticle2.emission;
        ParticleSystem.EmissionModule em3 = deathParticle3.emission;
        ParticleSystem.EmissionModule em4 = deathParticle4.emission;
        ParticleSystem.EmissionModule em5 = deathParticle5.emission;
        ParticleSystem.EmissionModule em6 = deathParticle6.emission;
        ParticleSystem.EmissionModule em7 = deathParticle7.emission;
        ParticleSystem.EmissionModule em8 = deathParticle8.emission;
        ParticleSystem.EmissionModule em9 = deathParticle9.emission;

        em1.enabled = false;
        em2.enabled = false;
        em3.enabled = false;
        em4.enabled = false;
        em5.enabled = false;
        em6.enabled = false;
        em7.enabled = false;
        em8.enabled = false;
        em9.enabled = false;
    }
}
