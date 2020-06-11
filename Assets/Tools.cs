using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{
    public static Color GetColorByNum(int n)
    {
        Color color = new Color();
        string colorHex;
        switch (n)
        {

            case -5:
                colorHex = "#1B2D30";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case -4:
                colorHex = "#3C595C";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case -3:
                colorHex = "#7DA8A7";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case -2:
                colorHex = "#BDD9D6";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case -1:
                colorHex = "#DDF3F2";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case 5:
                colorHex = "#FBB102";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case 4:
                colorHex = "#FCC427";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case 3:
                colorHex = "#FCD351";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case 2:
                colorHex = "#FEDE77";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case 1:
                colorHex = "#FEE797";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            case -100:
                colorHex = "#FF7F7F";
                ColorUtility.TryParseHtmlString(colorHex, out color);
                return color;
            default: return Color.white;
        }
    }

    public static string GetLocalWeekName(System.DateTime dateTime)
    {
        string weekname = dateTime.DayOfWeek.ToString();
        switch (weekname)
        {
            case "Monday":
                return "周一";
            case "Tuesday":
                return "周二";
            case "Wednesday":
                return "周三";
            case "Thursday":
                return "周四";
            case "Friday":
                return "周五";
            case "Saturday":
                return "周六";
            case "Sunday":
                return "周日";
            default: return "";
                //持戒 忍辱 省身 精进 明澈
        }
    }
    public static string GetLevelByNum(int n)
    {
        switch (n)
        {
            case -5:
            case -4:
                return "持戒";
            case -3:
            case -2:
                return "忍辱";
            case -1:
            case 1:
                return "省身";
            case 2:
            case 3:
                return "精进";
            case 4:
            case 5:
                return "明澈";
            default: return "";

        }
    }
}
