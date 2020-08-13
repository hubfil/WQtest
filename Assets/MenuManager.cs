using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject cameraMenu;
    public GameObject cameraOptions;
    public GameObject cameraGame;

    //еще
    public GameObject pauseMenu, WinMenu, LoseMenu;

    private void resetPanelosition()
    {
        cameraMenu.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        cameraOptions.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        cameraGame.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        pauseMenu.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        WinMenu.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        LoseMenu.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        pauseMenu.SetActive(false);
        WinMenu.SetActive(false);
        LoseMenu.SetActive(false);

    }

    public GameObject mSlider1, mSlider2;
    public string menuMusic, gameMusic;
    
    private void musicSliderSet()
    {
        mSlider1.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        mSlider2.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        mSlider1.GetComponent<UnityEngine.UI.Slider>().value = SoundManager.GetMusicVolume();
        mSlider2.GetComponent<UnityEngine.UI.Slider>().value = SoundManager.GetMusicVolume();

    }



    public static MenuManager instance = null; // Экземпляр объекта

    // Метод, выполняемый при старте игры
    void Start()
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

        // И запускаем собственно инициализатор
        InitializeManager();

        MenuB();
        resetPanelosition();
    }

    // Метод инициализации менеджера
    private void InitializeManager()
    {
        

        /* TODO: Здесь мы будем проводить инициализацию */
    }

    public void ButtonPress(string input)
    {
        SoundManager.PlaySoundUI("click1");
        Debug.Log(input);
        switch (input)
        {

            case "start":
                startB();
                break;

            case "options":
                OptionsB();
                break;

            case "exit":
                Application.Quit();
                break;

            case "menu":
                MenuB();
                break;
            

            case "d1":
                SetDifficulty(1);
                break;

            case "d2":
                SetDifficulty(2);
                break;

            case "d3":
                SetDifficulty(3);
                break;

            case "pause":
                Pause();
                break;

            case "pauseend":
                PauseEnd();
                break;


            default:
                break;
        }
    }


    //я не извращенец, но хочу попробовать
    void startB()
    {
        cameraGame.SetActive(true);
        cameraMenu.SetActive(false);
        cameraOptions.SetActive(false);

        
        SoundManager.PlayMusic(gameMusic);
        StartCoroutine(waitAndGo());
    }

    IEnumerator waitAndGo()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        Debug.Log("Time.timeScale = 1");
        FindObjectOfType<BallScript>().StartBall(); //потом
        Time.timeScale = 1;
    }

    void OptionsB()
    {
        cameraGame.SetActive(false);
        cameraMenu.SetActive(false);
        cameraOptions.SetActive(true);

    }

    void MenuB()
    {
        SoundManager.PlayMusic(menuMusic);
        Time.timeScale = 0;
        cameraGame.SetActive(false);
        cameraMenu.SetActive(true);
        cameraOptions.SetActive(false);

    }

    //извращения закончены


    void SetDifficulty(int diff)
    {

    }

    public static void Pause()
    {
        instance.pauseMenu.SetActive(true);
        Time.timeScale = 0;
        SoundManager.StopAllPausableSounds();
    }
    public static void PauseEnd()
    {
        instance.pauseMenu.SetActive(false);
        instance.LoseMenu.SetActive(false);
        instance.WinMenu.SetActive(false);

        SoundManager.UnPause();
        Time.timeScale = 1;
    }




    public static void ShowLosePanel()
    {
        instance.ShowLosePanel1();
    }

    private void ShowLosePanel1()
    {
        LoseMenu.SetActive(true);
        Time.timeScale = 0;

    }

    public static void showWinPanel()
    {
        instance.showWinPanel1();
    }
    private void showWinPanel1()
    {
        WinMenu.SetActive(true);
        Time.timeScale = 0;

    }
}
