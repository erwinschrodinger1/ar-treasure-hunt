using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArPageUIScripts : MonoBehaviour
{
    TMP_Text keycounter;
    // Start is called before the first frame update
    void Start()
    {
        keycounter = GameObject.Find("Canvas/Panel/KeyCounter").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        keycounter.text = ChestDropper.keys.ToString();
    }

    public void onClickMap()
    {
        Debug.Log("Goto Map");
    }
}
