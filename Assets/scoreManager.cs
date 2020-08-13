using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreManager : MonoBehaviour
{

    private static int score;
    private static int maxScore;

    

    public static scoreManager instance = null;


    public Vector3 ballStartPosition;
    public GameObject ballObj;

    //health
    public int health = 3;
    public GameObject[] hearts = new GameObject[3];
    private static Text scoreText;
    public Text scoreWinText, scoreLooseText;


    void Awake()
    {
        // Теперь, проверяем существование экземпляра
        if (instance == null)
        { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        }
        else if (instance == this)
        { // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }

        // Теперь нам нужно указать, чтобы объект не уничтожался
        // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);


        ballObj = FindObjectOfType<BallScript>().gameObject;
        ballStartPosition = ballObj.transform.position;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

    }


    #region health
    public static void staticLooseHealth()
    {
        instance.LooseHealth();
    }

    public void GiveHealth()
    {
        //    3    >    3
        if (health > hearts.Length)
        {
            hearts[health].SetActive(true);
            health++;
        }
        else
            Debug.Log("max health");
    }

    public void LooseHealth ()
    {
        Debug.Log("LooseHealth");
        //    3    <    3
        if (health <= hearts.Length)
        {
            Debug.Log("LooseHealth" + health);
            health--;
            hearts[health].SetActive(false);
        }
        else
        {
            Debug.Log("no health");
            MenuManager.ShowLosePanel();
        }

    }
    #endregion

    #region score
    public static void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        if (score == maxScore)
        {
            Debug.Log("win");
            MenuManager.showWinPanel();
        }
    }

    public static void resetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    #endregion

    public void RestartGo()
    {
        ballObj.transform.position = ballStartPosition;
        ballObj.GetComponent<BallScript>().StartBall();
        SoundManager.PlaySound("boom7").SetVolume(0.1f);
    }
}
