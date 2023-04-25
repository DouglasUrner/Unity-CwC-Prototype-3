using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public ParticleSystem dirtParticle;
  public ParticleSystem explosionParticle;

  public bool gameOver = false;
  public bool onGround = true;

  // Defaults, tune in the Inspector.
  public float jumpForce = 10.0f;
  public float gravityModifier = 1.0f;

  private Rigidbody playerRb;
  private Animator playerAnim;
  private GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("Game Manager").
      GetComponent<GameManager>();
    playerRb = GetComponent<Rigidbody>();
    playerAnim = GetComponent<Animator>();

    playerRb.AddForce(Vector3.up * jumpForce/4, ForceMode.Impulse);
  }

  // Update is called once per frame
  void Update()
  {
    // Tweak gravity here so that we can tune the value
    // without needing to restart.
    Physics.gravity *= gravityModifier;

    // Jump if we're on the ground and space is pressed.
    if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
    {
      onGround = false;
      playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      playerAnim.SetTrigger("Jump_trig");
      dirtParticle.Stop();
    }
  }

  void OnCollisionEnter(Collision c)
  {
    if (c.gameObject.CompareTag("Ground"))
    {
      onGround = true;

      dirtParticle.Play();
    }
    if (c.gameObject.CompareTag("Obstacle"))
    {
      // Debug.Log("Game Over");
      dirtParticle.Stop();
      explosionParticle.Play();
      playerAnim.SetBool("Death_b", true);
      playerAnim.SetInteger("DeathType_int", 1);

      gameOver = true;
      gameManager.gameEnding = true;
    }
  }
}
