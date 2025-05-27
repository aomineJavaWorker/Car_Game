using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public ObjectScript[] objectScripts;  // Список всех машин/объектов
    public GameObject winPanel;
    public Text timeText;
    public Text winTimeText;  // Новый текст внутри панели победы

    public Image winImage;           // Ссылка на Image в панели
    public Sprite[] winSprites;      // Список спрайтов, которые будут меняться
    public float imageChangeInterval = 15f;
    // Интервал смены картинки (в секундах)

    private float imageTimer = 0f;
    private int currentSpriteIndex = 0;
    private float winTimer = 0f; // Время после победы


    private float timer = 0f;
    private bool gameEnded = false;

    void Start()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(false);  // Скрыть панель в начале игры
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
        timeText.text = $"Время: {hours:D2}:{minutes:D2}:{seconds:D2}";
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

        timeText.text = "Поздравляем!";
        winTimeText.text = $"Ваше время: {formattedTime}";

        if (winSprites.Length > 0 && winImage != null)
        {
            if (timer < 30f)
                currentSpriteIndex = 0; // 3 звезды
            else if (timer < 45f)
                currentSpriteIndex = 1; // 2 звезды
            else
                currentSpriteIndex = 2; // 1 звезда

            winImage.sprite = winSprites[currentSpriteIndex];
        }
    }

}