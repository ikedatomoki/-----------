using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageText : MonoBehaviour
{
    public GameObject ResultText; 
    public Dropdown dropdown;
    int total;
    int select;
    string defaultText = "実質±0";
    string[] GameText = {"ゲームソフト","ゲームソフト(限定版)","3DS(中古)","Switch Lite","旧型Switch","新型Swich","Xbox","Switch＋ゲームソフト","ゲーミングモニター(27インチ)","PS5"};
    // string[] ClothesText = {""};
    string[] FoodText = {"ラーメン5杯","ラーメン10杯","ラーメン15杯","ラーメン20杯","ラーメン25杯","ラーメン30杯","ラーメン35杯","ラーメン40杯","ラーメン45杯","ラーメン50杯"};
    string[] CarText = {"ガソリン代","シートカバー","オーディオ","ホイール","シートカバー装着","ローダウン","内装カスタム","軽中古車本体価格","GT-Wing","チューニング"};

    // Start is called before the first frame update
    void Start()
    {
        // total = Mathf.Abs(PlayerPrefs.GetInt("Total"));
    }

    // Update is called once per frame
    void Update()
    {
        total = Mathf.Abs(PlayerPrefs.GetInt("Total"));
        if(dropdown.value == 0)
        {
            UpdateGame();
        }
        else if(dropdown.value == 1)
        {
            UpdateFood();
        }
        else
        {
            UpdateCar();
        }
    }

    public void UpdateGame()
    {
        for(int i= 0; i<GameText.GetLength(0)+1; i++ )
        {
            int threshold = 5000 + i * 5000;

            if(total < threshold)
            {
                ResultText.GetComponent<Text>().text = GameText[i-1];
                return;
            }
        }
        ResultText.GetComponent<Text>().text = defaultText;
    }

    public void UpdateFood()
    {
        for(int i= 0; i<FoodText.GetLength(0)+1; i++ )
        {
            int threshold = 5000 + i * 5000;

            if(total < threshold)
            {
                ResultText.GetComponent<Text>().text = FoodText[i-1];
                return;
            }
        }
        ResultText.GetComponent<Text>().text = defaultText;
    }

    public void UpdateCar()
    {
        for(int i= 0; i<GameText.GetLength(0)+1; i++ )
        {
            int threshold = 5000 + i * 5000;

            if(total < threshold)
            {
                ResultText.GetComponent<Text>().text = CarText[i-1];
                return;
            }
        }
        ResultText.GetComponent<Text>().text = defaultText;
    }
}
