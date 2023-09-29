using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHover : MonoBehaviour
{

  public GameObject gameManager;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(0))
    {
      gameManager.GetComponent<GameManager>().buildTower();
    }
    gameManager.GetComponent<GameManager>().selectedTower.transform.position = transform.position;
  }

  // on hover, set color to red
  void OnMouseEnter()
  {
    GetComponent<SpriteRenderer>().color = Color.green;
  }

  // on hover exit, set color to white
  void OnMouseExit()
  {
    GetComponent<SpriteRenderer>().color = Color.white;
  }
}
