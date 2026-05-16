using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIntUpdate : MonoBehaviour
{
    public SOInt soUInt;
    public TextMeshProUGUI uiTextValue;

    // Start is called before the first frame update
    void Start()
    {
        uiTextValue.text = soUInt.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextValue.text = soUInt.value.ToString();
    }
}
