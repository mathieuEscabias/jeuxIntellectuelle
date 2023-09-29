using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private int playerLife = 10;
    private int playerMoney = 1000;
    private int playerScore = 0;

    // UI 
    public GameObject playerLifeDisplay;
    public GameObject playerMoneyDisplay;
    public GameObject playerScoreDisplay;

    public GameObject linkTowerPrefab;
    public GameObject towersParent;

    public GameObject selectedTower;

    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        selectedTower = Instantiate(linkTowerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        playerLifeDisplay.GetComponent<UnityEngine.UI.Text>().text = playerLife.ToString();
        playerScoreDisplay.GetComponent<UnityEngine.UI.Text>().text = playerScore.ToString();
        towersParent = GameObject.Find("Towers");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setPlayerLife(int life)
    {
        playerLife = life;
        playerLifeDisplay.GetComponent<UnityEngine.UI.Text>().text = playerLife.ToString();
        if (playerLife <= 0)
        {
            Application.Quit();
        }
    }
    public void playerLoseLife(int damage)
    {
        setPlayerLife(playerLife - damage);
    }
    public void playerIncreaseScore(int bonus)
    {
        playerScore += bonus;
        playerScoreDisplay.GetComponent<UnityEngine.UI.Text>().text = playerScore.ToString();
    }

    public void buildTower()
    {
        selectedTower = Instantiate(linkTowerPrefab, new Vector3(0, 0, 0), Quaternion.identity, towersParent.transform);
    }
}
