using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int playerLife = 10;
    public int playerMoney = 1000;
    public int playerScore = 0;

    // UI 
    public GameObject playerLifeDisplay;
    public GameObject playerMoneyDisplay;
    public GameObject playerScoreDisplay;

    public GameObject linkTowerPrefab;

    public GameObject selectedTower;

    // Start is called before the first frame update
    void Start()
    {
        selectedTower = Instantiate(linkTowerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        playerLifeDisplay.GetComponent<UnityEngine.UI.Text>().text = playerLife.ToString();
        // playerMoneyDisplay.GetComponent<UnityEngine.UI.Text>().text = playerMoney.ToString();
        // playerScoreDisplay.GetComponent<UnityEngine.UI.Text>().text = playerScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setPlayerLife(int life)
    {
        playerLife = life;
        playerLifeDisplay.GetComponent<UnityEngine.UI.Text>().text = playerLife.ToString();
        if( playerLife <= 0)
        {
            Debug.Log("Game Over");
            // Quit game 
            Application.Quit();
        }
    }
    public void playerLoseLife(int damage)
    {
        setPlayerLife(playerLife - damage);
    }

    public void selectTower()
    {
        Debug.Log("Select tower");
    }
}
