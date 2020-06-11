using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckManager : MonoBehaviour
{
    //private DataManager _instance;
    //Dictionary<System.DateTime, int> Timedic = new Dictionary<System.DateTime, int>();
    public GameObject dayPrefab;
    public GameObject today;
    public GameObject scrollRect;
    public Transform daysContent;
    void Start()
    {
        //DateTime.DaysInMonth(year, month) 就是获得year年的month月 有多少天
        //print(System.DateTime.Now.Day);
        //print(System.DateTime.Now.Month);
        //print(System.DateTime.Now.Year);
        //print(System.DateTime.Today);
        
        CreateCheckList();


    }

  
    public void CreateCheckList()
    {
        //先删除除today之外的所有子物体
        foreach (Transform child in daysContent)
        {
            if(child.gameObject.name != "Today")
            {
                Destroy(child.gameObject);
            }
        }

        System.DateTime currentdate = new System.DateTime();
        currentdate = System.DateTime.Today;
        for (int i = 0; i < 30; i++)
        {
            if (i == 0)
            {
             
                
            }
            else
            if (DataManager._instance.Timedic.ContainsKey(currentdate))
            {
                //表示有记录
                GameObject day = Instantiate(dayPrefab, daysContent);
                //11月11日 周日 +5
                string dateString = currentdate.Month + "月" + currentdate.Day + "日";
                string weekNameString = Tools.GetLocalWeekName(currentdate);
                int score = DataManager._instance.Timedic[currentdate];
                string level = Tools.GetLevelByNum(score);
                day.GetComponent<DayPanel>().SetContext(dateString, weekNameString, level, score.ToString());

                day.GetComponent<Image>().color = Tools.GetColorByNum(score);
                //day.GetComponent<Image>().color = Color.black;
                if(score == 1 || score == 2 || score == -1 || score == -2)
                {
                    day.GetComponent<DayPanel>().SetColor(Color.black);
                }
            }
            else
            {
                //没有记录
                GameObject day = Instantiate(dayPrefab, daysContent);
                //11月11日 周日 +5
                string dateString = currentdate.Month + "月" + currentdate.Day + "日";
                
                string weekNameString = Tools.GetLocalWeekName(currentdate);
                string score = "？";
                string level = Tools.GetLevelByNum(-100);
                day.GetComponent<DayPanel>().SetContext(dateString, weekNameString, level, score);
                //day.GetComponent<Image>().color = new Color(207, 207, 207);
                day.GetComponent<Image>().color = Tools.GetColorByNum(-100);
                //day.GetComponent<Image>().color = Color.red;

            }
            currentdate = currentdate.AddDays(-1);
        }
        scrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 0;
        //daysContent.position.y = -1780;
        //scroll rect 滚动问题   折线图  button效果 
    }

}
