using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
  private float step;
  private Vector3 startPosition;

  // Start is called before the first frame update
  void Start()
  {
    startPosition = transform.position;
    step = GetComponent<BoxCollider>().size.x / 2;
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.x < startPosition.x - step)
    {
      transform.position = startPosition;
    }
  }
}
