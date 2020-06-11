using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayPanel : MonoBehaviour {
    public Text DateText;
    public Text WeekText;
    public Text ScoreText;
    public Text LevelText;
    public Image SilceImage;

    //11月11日 周日 +5
	public void SetContext(string date, string week, string level, string score)
    {
        DateText.text = date;
        WeekText.text = week;
        ScoreText.text = score;
        LevelText.text = level;
    }
    public void SetColor(Color color)
    {
        DateText.color = color;
        WeekText.color = color;
        ScoreText.color = color;
        LevelText.color = color;
        SilceImage.color = color;
    }
}
