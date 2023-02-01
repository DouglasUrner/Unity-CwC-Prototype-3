using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  // Defaults, tune in the Inspector.
  public float jumpForce = 10.0f;
  public float gravityModifier = 1.0f;

  private Rigidbody playerRb;

  // Start is called before the first frame update
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
  }

  // Update is called once per frame
  void Update()
  {
    // Tweak gravity here so that we can tune the value
    // without needing to restart.
    Physics.gravity *= gravityModifier;
  }
}
