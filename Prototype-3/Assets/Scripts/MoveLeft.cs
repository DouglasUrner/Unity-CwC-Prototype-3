using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
  // Defaults, tune in the Inspector.
  public float speed = 10;
  public float leftBound = -5;

  private PlayerController playerController;

  // Start is called before the first frame update
  void Start()
  {
    playerController = GameObject.Find("Player").
      GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (playerController.gameOver) { return; }

    transform.Translate(Vector3.left * speed * Time.deltaTime);

    if (transform.position.x < leftBound &&
      gameObject.CompareTag("Obstacle"))
    {
      Destroy(gameObject);
    }
  }
}
