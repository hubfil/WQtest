using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    private void Start()
    {
        instance = this;
    }
    public static void whatchYoutube()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=fdyuOiciwB4/");
    }

}