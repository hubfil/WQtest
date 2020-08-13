using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject cameraMenu;
    public GameObject cameraOptions;
    public GameObject cameraGame;

    public string menuMusic, gameMusic;




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
}
