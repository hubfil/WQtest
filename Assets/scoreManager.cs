using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreManager : MonoBehaviour
{

    private static int score;
    public  int maxScore;



    public static scoreManager instance = null;


    public Vector3 ballStartPosition;
    public GameObject ballObj;

    //health
    public int health = 3;
    public GameObject[] hearts = new GameObject[3];
    private static Text scoreText;
    public Text scoreWinText, scoreLooseText;


    public GameObject bricksPrefab, bricks;


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
        Debug.Log("GiveHealth");
        //    0    >    1
        if ( health < 3)
        {
            hearts[health].SetActive(true);
            health++;
        }
        else
            Debug.Log("max health");
    }

    public void LooseHealth()
    {
        Debug.Log("LooseHealth");
        //    3    <    3
        if (health > 0 && (health == 3 ||  health < hearts.Length))
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
        if (score % instance.maxScore == 0)
        {
            Debug.Log("win");
            instance.StartCoroutine(instance.ShowWin());
        }
        instance.syncScoreText();
    }

    IEnumerator ShowWin()
    {
        yield return new WaitForSecondsRealtime(0.2f);

        MenuManager.showWinPanel();

    }

    private void syncScoreText()
    {
        scoreWinText.text = "score " + score;
        scoreLooseText.text = "score " + score;

        
    }

    public static void resetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    #endregion

    public static void allRestart()
    {
        instance.RestartGo();
    }

    public void RestartGo()
    {
        score = 0;
        GiveHealth(); GiveHealth();
        GiveHealth();
        GiveHealth();


        ballObj.transform.position = ballStartPosition;
        ballObj.GetComponent<BallScript>().StartBall();
        SoundManager.PlaySound("phaserUp1").SetVolume(2.1f);

        #region bricks management

        Transform bricksPos = bricks.transform;
        for (int i = 0; i < bricks.transform.childCount; i++)
            Destroy(bricks.transform.GetChild(i).gameObject);
        GameObject newBricks = Instantiate(bricksPrefab, bricks.transform);
        for (int i = 0; i < newBricks.transform.childCount; i++)
            newBricks.transform.GetChild(i).transform.parent = bricks.transform;

        #endregion

        MenuManager.PauseEnd();
    }

    public void PayedOption()
    {
        GiveHealth();
        AdManager.whatchYoutube();
        MenuManager.PauseEnd();
        MenuManager.Pause();
    }



    public void nextLevel()
    {
        //score = 0;
        GiveHealth();


        ballObj.transform.position = ballStartPosition;
        ballObj.GetComponent<BallScript>().StartBall();
        SoundManager.PlaySound("phaserUp1").SetVolume(2.1f);

        #region bricks management

        Transform bricksPos = bricks.transform;
        for (int i = 0; i < bricks.transform.childCount; i++)
            Destroy(bricks.transform.GetChild(i).gameObject);
        GameObject newBricks = Instantiate(bricksPrefab, bricks.transform);
        for (int i = 0; i < newBricks.transform.childCount; i++)
            newBricks.transform.GetChild(i).transform.parent = bricks.transform;

        #endregion

        MenuManager.PauseEnd();
    }

}
