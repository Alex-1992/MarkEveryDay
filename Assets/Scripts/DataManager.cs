using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager _instance;
    [SerializeField]
    public Dictionary<System.DateTime, int> Timedic = new Dictionary<System.DateTime, int>();
    public int totalScore = 0;
    public int totalDays = 0;
    public int markedDays = 0;
    public System.DateTime lastUpLoadDate;
    public GameObject today;

    private void Awake()
    {
        _instance = this;
        
        if (File.Exists(Application.dataPath + "/StreamingFile" + "/byBin.txt"))
        //表示有存储的数据 加载数据
        {
            LoadData();
            if (Timedic.ContainsKey(System.DateTime.Today))
            //表示用户今天已经记录过了
            {
                //TodayPanel.isClicked = true;
                //today.GetComponent<TodayPanel>().SetNormalDay(Timedic[System.DateTime.Today]);
            }
            else if (System.DateTime.Compare(lastUpLoadDate, System.DateTime.Today.AddDays(-1)) != 0)
            //表示今天还没记录 并且昨天或者前几天也没记录
            {
                System.TimeSpan ts = System.DateTime.Today.AddDays(-1).Subtract(lastUpLoadDate);
                totalDays += (int)ts.TotalDays;
            }
        }
        else
        {
            //没有数据 用户首次使用
            //生成测试数据
            System.DateTime dateTime = new System.DateTime();
            dateTime = System.DateTime.Today;
            for (int i = 1; i < 31; i++)
            {
                totalDays++;
                if ((int)Random.Range(0, 10) < 1) continue;
                int tempNum = Random.Range(-5, 5);
                if (tempNum >= 0) tempNum++;

                totalScore += tempNum;
                markedDays++;
                Timedic.Add(dateTime.AddDays(-i), tempNum);
            }
        }


       
    }
    void Start()
    {
        //SaveData();
    }

    public void SaveByBin()
    {
       
        //创建一个二进制格式化程序
        BinaryFormatter bf = new BinaryFormatter();
        //创建一个文件流
        FileStream fileStream = File.Create(Application.dataPath + "/StreamingFile" + "/byBin.txt");
        //用二进制格式化程序的序列化方法来序列化Save对象,参数：创建的文件流和需要序列化的对象
        bf.Serialize(fileStream, Timedic);
        //关闭流
        fileStream.Close();

        //如果文件存在，则显示保存成功
        if (File.Exists(Application.dataPath + "/StreamingFile" + "/byBin.txt"))
        {
            print("保存成功");
        }
    }

    private void LoadByBin()
    {
        if (File.Exists(Application.dataPath + "/StreamingFile" + "/byBin.txt"))
        {
            //反序列化过程
            //创建一个二进制格式化程序
            BinaryFormatter bf = new BinaryFormatter();
            //打开一个文件流
            FileStream fileStream = File.Open(Application.dataPath + "/StreamingFile" + "/byBin.txt", FileMode.Open);
            //调用格式化程序的反序列化方法，将文件流转换为一个Save对象
            Timedic = (Dictionary<System.DateTime, int>) bf.Deserialize(fileStream);
            //关闭文件流
            fileStream.Close();
        }
        else
        {
            print("文档不存在！");
        }

    }

    private void LoadData()
    {
        //DateTime localDate2 = DateTime.FromBinary(binLocal);
        totalDays = PlayerPrefs.GetInt("totalDays");
        totalScore = PlayerPrefs.GetInt("totalScore");
        markedDays = PlayerPrefs.GetInt("markedDays");
        print(PlayerPrefs.GetString("lastUpLoadDate"));
        lastUpLoadDate = System.DateTime.Parse(PlayerPrefs.GetString("lastUpLoadDate"));
        print(lastUpLoadDate);
        LoadByBin();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("totalDays", totalDays);
        PlayerPrefs.SetInt("totalScore", totalScore);
        PlayerPrefs.SetInt("markedDays", markedDays);
        PlayerPrefs.SetString("lastUpLoadDate", System.DateTime.Today.ToString());
        SaveByBin();
    }

}
