using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalManager : MonoBehaviour {
    public Text TotalScore;
    public Text AvgScore;
    public Text TotalDays;
    public Text MarkedDays;
    public Text MissedDays;
    public Text BadRecordPercent;
    public Text GoodRecordPercent;
    public RectTransform BadImg;
    public RectTransform MissImg;
    public RectTransform GoodImg;
    public void ShowTotal()
    {
        TotalScore.text = DataManager._instance.totalScore.ToString();
        AvgScore.text = Math.Round((float)DataManager._instance.totalScore /DataManager._instance.markedDays, 1) + "";
        TotalDays.text = DataManager._instance.totalDays.ToString();
        MarkedDays.text = DataManager._instance.markedDays.ToString();
        MissedDays.text = (DataManager._instance.totalDays - DataManager._instance.markedDays).ToString();
        SetImgPercent();
        
    }
    private void SetImgPercent()
    {
        System.DateTime dateTime = new System.DateTime();
        dateTime = System.DateTime.Today;
        int goodNum = 0;
        int badNum = 0;
        int missNum = 0;
        for (int i = 1; i < 11; i++)
        {
            if (DataManager._instance.Timedic.ContainsKey(dateTime.AddDays(-i)))
            {
                if (DataManager._instance.Timedic[dateTime.AddDays(-i)] >= 0)
                {
                    goodNum++;
                }
                else
                {
                    badNum++;
                }
            }
            else
            {
                missNum++;
                //表示此天未记录
            }
        }
        int totalNum = goodNum + missNum + badNum;
        BadImg.GetComponent<RectTransform>().sizeDelta = new Vector2(1080 * badNum /totalNum, 110);
        GoodImg.GetComponent<RectTransform>().sizeDelta = new Vector2(1080 * goodNum /totalNum, 110);
        MissImg.GetComponent<RectTransform>().sizeDelta = new Vector2(1080 * missNum /totalNum, 110);
        BadRecordPercent.text = Math.Round ((float)badNum / totalNum,2)*100 + "%";
        GoodRecordPercent.text = Math.Round((float)goodNum / totalNum, 2) * 100 + "%";
    }
}
