using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI;

public class TodayPanel : DayPanel
{
    private GameObject choosePanel;
    //public static bool isClicked = false;
    //public GameObject dateText;
    //public GameObject weekText;
    // Use this for initialization
    void Awake()
    {
        GameObject root = GameObject.Find("Check");
        choosePanel = root.transform.Find("BtnPanel").gameObject;

        //今天
        //11月11日 周日 +5
        System.DateTime currentdate = new System.DateTime();
        currentdate = System.DateTime.Today;
        string dateString = currentdate.Month + "月" + currentdate.Day + "日";
        string weekNameString = Tools.GetLocalWeekName(currentdate);
        if (!DataManager._instance.Timedic.ContainsKey(System.DateTime.Today))
        {
            string score = "+";
            SetContext(dateString, weekNameString, "今天", score);
        }
        else
        {
            SetNormalDay(DataManager._instance.Timedic[System.DateTime.Today]);
        }
        
    }

    public void OnClick()
    {
        choosePanel.SetActive(true);
    }
    public void SetNormalDay(int score)
    {
        print("SetNormalDay  score:" + score);
        //todayText.SetActive(false);
        //DateText.gameObject.SetActive(true);
        //WeekText.gameObject.SetActive(true);
        ScoreText.text = score.ToString();
        LevelText.text = Tools.GetLevelByNum(score);
        Destroy(gameObject.GetComponent<Button>());
        //设置颜色
        gameObject.GetComponent<Image>().color = Tools.GetColorByNum(score);
        if (score == 1 || score == 2 || score == -1 || score == -2)
        {
            gameObject.GetComponent<DayPanel>().SetColor(Color.black);
        }
        //存储数据
        if(!DataManager._instance.Timedic.ContainsKey(System.DateTime.Today))
        {
            DataManager._instance.markedDays++;
            DataManager._instance.totalDays++;
            DataManager._instance.totalScore += score;
            DataManager._instance.Timedic.Add(System.DateTime.Today, score);
            DataManager._instance.SaveData();
        }
    }
}
