using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;


public class Calculator : MonoBehaviour
{
    // ?????e?L?X?g
    public Text INVInput;
    public Text GETInput;

    // ?e?????{?^??
    public Button[] bNumber;

    // ???????????e?L?X?g??int?^???????i?[????????
    private int textToInt;
    private int textToInt_GET;

    // Calculator?i?d???j?I?u?W?F?N?g???i?[????????
    public GameObject targetObject;
    public GameObject total;

    // GameManager???????????g??.
    private GameManager gm;

    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    // ?e?????{?^??????
    public void InputNumber(Text number)
    {
        if (gm.isAliveINV)
        {
            INVInput.text += number.text;
        }
        if (gm.isAliveGET)
        {
            GETInput.text += number.text;
        }
    }

    // E?i?m???j?{?^??????
    public void InputEnter()
    {
        // ?{?^?????N???b?N????????????GameObject?????A?N?e?B?u??????
        if (targetObject != null)
        {
            if (gm.isAliveINV & INVInput.text != "")
            {
                textToInt = int.Parse(INVInput.text);
            }
            if (gm.isAliveGET & GETInput.text != "")
            {
                textToInt_GET = int.Parse(GETInput.text);
            }
            targetObject.SetActive(false);
            PlayerPrefs.SetInt("INV", textToInt);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("GET", textToInt_GET);
            PlayerPrefs.Save();
            int inv = PlayerPrefs.GetInt("INV");
            int get = PlayerPrefs.GetInt("GET");
            int money = inv * -1 + get;
            total.GetComponent<Text>().text = money.ToString();
            UnityEngine.Debug.Log(textToInt);
            UnityEngine.Debug.Log(textToInt_GET);
        }
    }

    // ?N???A?{?^??????
    public void InputClear()
    {
        if (gm.isAliveINV)
        {
            INVInput.text = "";
        }
        if (gm.isAliveGET)
        {
            GETInput.text = "";
        }
    }
}
