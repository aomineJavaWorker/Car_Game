﻿using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public ObjectScript[] objectScripts;   // Visu mašīnu/objektu saraksts
    public GameObject winPanel;
    public Text timeText;
    public Text winTimeText;  // Jauns teksts uzvaras panelī

    public Image winImage;           // Attēlu panelīs
    public Sprite[] winSprites;      // Saraksts ar attēliem kas mainīsies
    public float imageChangeInterval = 15f;

    private float imageTimer = 0f;
    private int currentSpriteIndex = 0;
    private float winTimer = 0f;


    private float timer = 0f;
    private bool gameEnded = false;

    void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);  // Panele ir aiztaisīta spēles sākumā
        }
    }

    void Update()
    {
        if (!gameEnded)
        {
            timer += Time.deltaTime;
            UpdateTimeText();
            CheckVictoryCondition();
        }
    }




    void UpdateTimeText()
    {
        int hours = (int)(timer / 3600);
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);
        timeText.text = $"Laiks: {hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    public void CheckVictoryCondition()
    {
        if (AllVehiclesPlacedCorrectly() && !gameEnded)
        {
            gameEnded = true;
            ShowWinPanel();
        }
    }

    private bool AllVehiclesPlacedCorrectly()
    {
        foreach (var obj in objectScripts)
        {
            if (!(obj.isGarbagePlaced &&
                  obj.isMedicPlaced &&
                  obj.isSchoolBuss &&
                  obj.isCement &&
                  obj.isE46 &&
                  obj.isE61 &&
                  obj.isB2 &&
                  obj.isPolicija &&
                  obj.isEskavators &&
                  obj.isTraktors1 &&
                  obj.isTraktors5 &&
                  obj.isUgunsdzeseji))
            {
                return false;
            }
        }
        return true;
    }

    private void ShowWinPanel()
    {
        winPanel.SetActive(true);

        int hours = (int)(timer / 3600);
        int minutes = (int)(timer / 60) % 60;
        int seconds = (int)(timer % 60);
        string formattedTime = $"{hours:D2}:{minutes:D2}:{seconds:D2}";

        timeText.text = "Apsveicam!";
        winTimeText.text = $"Jūsu laiks: {formattedTime}";

        if (winSprites.Length > 0 && winImage != null)
        {
            if (timer < 60)
                currentSpriteIndex = 0; // 3 zvaigznes
            else if (timer < 120)
                currentSpriteIndex = 1; // 2 zvaigzns
            else
                currentSpriteIndex = 2; // 1 zvaigzne

            winImage.sprite = winSprites[currentSpriteIndex];
        }
    }

}