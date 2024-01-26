using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Type : MonoBehaviour
{
    public GameObject DayText;
    int total;

    // Start is called before the first frame update
    void Start()
    {
        string date = PlayerPrefs.GetString("DayDate");
        DayText.GetComponent<Text>().text = date;
        total = PlayerPrefs.GetInt("Total");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PushOKButton()
    {
        //money 投資 * -1 + 回収（電卓）
        int inv = PlayerPrefs.GetInt("INV");
        int get = PlayerPrefs.GetInt("GET");
        int money = inv * -1 + get;
        PlayerPrefs.SetInt("Total", total + money);
        PlayerPrefs.Save();

        SceneManager.LoadScene("CalendarScene");
    }
}
