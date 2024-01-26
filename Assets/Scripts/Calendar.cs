using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Calendar : MonoBehaviour
{
    // UnityのUIオブジェクトを保持するための変数
    public GameObject canvas; // カレンダーの親要素
    public GameObject prefab; // ボタンなどのプレハブ
    public GameObject TextYMD; // 年月日を表示するテキスト
    public GameObject TextMoney; //　合計収支を表示するテキスト

    // カレンダーで選択された日付を保持するための変数
    public static DateTime SelectDate;

    private DateTime D_Date; // 計算用の日付
    private int startday; // 月の最初の曜日のインデックス

    void Start()
    {        
        // カレンダーのセルを42個生成する
        for (int i = 0; i < 42; i++)
        {
            // プレハブからボタンを生成し、canvasの子要素にする
            GameObject button = Instantiate(prefab, canvas.transform);
            // ここでボタンに対する設定などを行うことができる
            button.GetComponent<Button>();
        }
        // 初期値として現在の日付を設定し、カレンダーを更新する
        SelectDate = DateTime.Now;
        CalendarController();
    }

    private void Update()
    {
        int total = PlayerPrefs.GetInt("Total");
        TextMoney.GetComponent<Text>().text = total.ToString();

    }

    // カレンダーを更新するメソッド
    private void CalendarController()
    {
        // 初期化
        int days = 1;
        int overday = 1;

        // 選択された月の1日を取得する
        D_Date = new DateTime(SelectDate.Year, SelectDate.Month, 1);
        int year = SelectDate.Year; // 年
        int month = SelectDate.Month; // 月
        int day = SelectDate.Day; // 日
        // 1日の曜日を取得する
        DayOfWeek firstDate = D_Date.DayOfWeek;
        // 月の日数を取得する
        int monthEnd = DateTime.DaysInMonth(year, month);
        // 前月の日数を計算する
        SelectDate = SelectDate.AddMonths(-1);
        month = SelectDate.Month;
        SelectDate = SelectDate.AddMonths(1);
        int lastmonth = DateTime.DaysInMonth(year, month);
        // 1日の曜日から先月の日数を求める
        switch (firstDate)
        {
            case DayOfWeek.Sunday:
                startday = 0;
                break;
            case DayOfWeek.Monday:
                startday = 1;
                break;
            case DayOfWeek.Tuesday:
                startday = 2;
                break;
            case DayOfWeek.Wednesday:
                startday = 3;
                break;
            case DayOfWeek.Thursday:
                startday = 4;
                break;
            case DayOfWeek.Friday:
                startday = 5;
                break;
            case DayOfWeek.Saturday:
                startday = 6;
                break;
        }
        int lastmonthdays = lastmonth - startday + 1;

        // カレンダーのセルを更新する
        for (int i = 0; i < 42; i++)
        {
            if (i >= startday)
            {
                if (days <= monthEnd)
                {
                    // 日付を表示する
                    Transform DAY = GameObject.Find("GameObject").transform.GetChild(i);
                    DateTime tmp = D_Date;
                    string ymd = D_Date.ToString("yyyy/MM/dd");
                    DayOfWeek num = tmp.DayOfWeek;
                    // 曜日によって色を変える
                    switch (num)
                    {
                        case DayOfWeek.Sunday:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.red;
                            break;
                        case DayOfWeek.Saturday:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.blue;
                            break;
                        default:
                            DAY.GetChild(0).GetComponent<Text>().color = Color.black;
                            break;

                    }
                    DAY.GetChild(0).GetComponent<Text>().text = D_Date.Day.ToString();
                    // ボタンにクリックイベントを追加する
                    GameObject button = GameObject.Find("GameObject").transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    button.GetComponent<Button>().onClick.AddListener(() => { set_Date(tmp); });
                    button.GetComponent<Button>().onClick.AddListener(() => { set_Tmp(ymd); });
                    D_Date = D_Date.AddDays(1);
                    days++;
                }
                else
                {
                    // 月の最後の日以降は灰色で表示する
                    Transform DAY = GameObject.Find("GameObject").transform.GetChild(i);
                    DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                    DAY.GetChild(0).GetComponent<Text>().text = overday.ToString();
                    GameObject button = GameObject.Find("GameObject").transform.GetChild(i).gameObject;
                    button.GetComponent<Button>().onClick.RemoveAllListeners();
                    overday++;
                }
            }
            else
            {
                // 先月の日を灰色で表示する
                Transform DAY = GameObject.Find("GameObject").transform.GetChild(i);
                DAY.GetChild(0).GetComponent<Text>().color = Color.gray;
                DAY.GetChild(0).GetComponent<Text>().text = lastmonthdays.ToString();
                GameObject button = GameObject.Find("GameObject").transform.GetChild(i).gameObject;
                button.GetComponent<Button>().onClick.RemoveAllListeners();
                lastmonthdays++;
            }
        }

        // 日付が選択されたときの処理
        void set_Date(DateTime date)
        {
            Debug.Log(date);
            // ここに日付が選択されたときの処理を記述する

            SceneManager.LoadScene("TypeScene");
        }

        // 選択された日付を表示する
        void set_Tmp(string ymd)
        {
            TextYMD.GetComponent<Text>().text = ymd;
            PlayerPrefs.SetString("DayDate",ymd);
            PlayerPrefs.Save();
        }
    }

    public void reset()
    {
        //合計収支を最初に0で保存
        PlayerPrefs.SetInt("Total", 0);
        PlayerPrefs.Save();
    }
}
