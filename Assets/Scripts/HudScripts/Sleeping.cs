using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sleeping : MonoBehaviour
{
    public string nextLevel;
    public int levelTime;
    private GameObject slepText;
    private void Start()
    {
        slepText = GameObject.Find("/SleepingCanvas/SleepingText");
        TextMeshProUGUI textInside = slepText.GetComponent<TextMeshProUGUI>();
        if (Hud.GetCurrent()-1 == 0)
        {
            Debug.Log("teraz");
            textInside.text = "Budzisz si� pod wiecz�r\r\nCzy mi si� wydaje czy co� tu si� zmieni�o?\r\n\r\n";
        }
        else
        {
            textInside.text = "D�wi�ki cichn�, a ty usypiasz \r\n Po chwili jednak ponownie si� wybudzasz\r\n\r\n";
        }
        nextLevel = Hud.Levels[Hud.GetCurrent()];
        levelTime = Hud.LevelsTimes[Hud.GetCurrent()];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Timer.SetTime(levelTime);
            OutlineSelection.CleanSelection();
            SceneManager.LoadScene(nextLevel);
        }
    }
}
