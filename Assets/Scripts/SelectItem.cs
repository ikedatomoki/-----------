using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItem : MonoBehaviour
{
    private Dropdown dropdown;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(dropdown.value == 0)
        {
            PlayerPrefs.SetInt("Select", dropdown.value);
            PlayerPrefs.Save();
        }
        else if(dropdown.value == 1)
        {
            PlayerPrefs.SetInt("Select", dropdown.value);
            PlayerPrefs.Save();
        }
    }
}
