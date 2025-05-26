using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public ObjectScript[] objectScripts;  // Список всех машин/объектов
    public GameObject winPanel;
    public Text timeText;
    public Text winTimeText;  // Новый текст внутри панели победы


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
        CheckVictoryCondition();
        if (!gameEnded)
        {
            timer += Time.deltaTime;
            UpdateTimeText();
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
    }

}
