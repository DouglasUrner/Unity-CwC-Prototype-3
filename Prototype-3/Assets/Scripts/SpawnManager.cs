using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  // Defaults, tune in the Inspector.
  public float startDelay = 1.0f;
  public float spawnIntervalMin = 1.0f;
  public float spawnIntervalMax = 3.0f;
  public Vector3 spawnRange = new Vector3(10, 0, 0);

  public GameObject[] objects;  // Initialize in Inspector

  private PlayerController playerController;
  private GameManager gameManager;

  // Start is called before the first frame update
  void Start()
  {
    playerController = GameObject.Find("Player").
      GetComponent<PlayerController>();
    Invoke("SpawnRandomObject", startDelay);
  }

  // Update is called once per frame
  void SpawnRandomObject()
  {
    if (playerController.gameOver) { return; }

    var i = Random.Range(0, objects.Length);
    Instantiate(objects[i], transform.position, objects[i].transform.rotation);

    Invoke("SpawnRandomObject", Random.Range(spawnIntervalMin, spawnIntervalMax));
  }
}
