using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public bool gameOver = false;
  public bool onGround = true;

  // Defaults, tune in the Inspector.
  public float jumpForce = 10.0f;
  public float gravityModifier = 1.0f;

  private Rigidbody playerRb;
  private GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("Game Manager").
      GetComponent<GameManager>();
    playerRb = GetComponent<Rigidbody>();
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
      playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      onGround = false;
    }
  }

  void OnCollisionEnter(Collision c)
  {
    if (c.gameObject.CompareTag("Ground"))
    {
      onGround = true;
    }
    if (c.gameObject.CompareTag("Obstacle"))
    {
      gameOver = true;
      gameManager.gameEnding = true;
    }
  }
}
