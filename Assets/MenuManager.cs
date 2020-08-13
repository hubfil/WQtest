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
        SoundManager.PlayMusic(menuMusic);
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

        FindObjectOfType<BallScript>().StartBall(); //потом
        SoundManager.PlayMusic(gameMusic);
    }

    void OptionsB()
    {
        cameraGame.SetActive(false);
        cameraMenu.SetActive(false);
        cameraOptions.SetActive(true);

    }

    void MenuB()
    {
        cameraGame.SetActive(false);
        cameraMenu.SetActive(true);
        cameraOptions.SetActive(false);

    }

    //извращения закончены


    void SetDifficulty(int diff)
    {

    }

    void Pause()
    {

    }


    public static void ShowLosePanel()
    {

    }

    public static void showWinPanel()
    {

    }
}
