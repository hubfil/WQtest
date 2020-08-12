using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float oldMousePos;
    public float sensiv;
    public GameObject playerObj;
    public float playerPosZ, playerPosY;
    public float playerPosMin, playerPosMax;

    public static PlayerManager instance = null; // Экземпляр объекта

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
    }

    // Метод инициализации менеджера
    private void InitializeManager()
    {
        /* TODO: Здесь мы будем проводить инициализацию */
        playerPosZ = playerObj.transform.position.z;

        playerPosY = playerObj.transform.position.y;
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float currPos = Input.mousePosition.x;
            float deltaY = oldMousePos - currPos;
            Debug.Log(deltaY);
            playerObj.transform.position = playerObj.transform.position +
                new Vector3(deltaY * sensiv, 0, 0);
            if (playerObj.transform.position.x > playerPosMax)
            {
                playerObj.transform.position = new Vector3(playerPosMax, playerPosY, playerPosZ);
            }
            if (playerObj.transform.position.x < playerPosMin)
            {
                playerObj.transform.position = new Vector3(playerPosMin, playerPosY, playerPosZ);
            }

        }
        else
        {
            oldMousePos = Input.mousePosition.x;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.deltaPosition.y);
            playerObj.transform.position = playerObj.transform.position +
                new Vector3(touch.deltaPosition.y * sensiv,0,0);
        }
    }
}
