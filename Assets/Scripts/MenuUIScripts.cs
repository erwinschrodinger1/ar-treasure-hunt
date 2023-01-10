using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Firebase.Database;
using Newtonsoft.Json;


public class Hints
{
    public string clue;
    public bool completed;
}
public class usersDetails
{
    public string code { get; set; }
    public List<Hints> hints { get; set; }
}


public class MenuUIScripts : MonoBehaviour
{
    public static List<Hints> userHints;
    DatabaseReference reference;
    List<usersDetails> deserializedData;

    string inputField;
    // Start is called before the first frame update
    void Start()
    {
        //reference to fetch data from firebase
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        Debug.Log(reference);
        //extracts data from db
        dbExtractor();
    }


    // Update is called once per frame
    void Update()
    {

    }

    //function used as useState for textfield reactDev problems lol
    public void onChangeValue(string s)
    {
        inputField = s;
    }
    public void onButtonClicked()
    {
        if (checkData())
        {
            Debug.Log("Clue of menuuiscript is " + userHints[0].clue);
            Debug.Log("right code");
            //changing scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("wrong code");
        }
    }
    bool checkData()
    {
        foreach (usersDetails iteam in deserializedData)
        {
            if (iteam.code == inputField)
            {
                userHints = iteam.hints;
                return true;
            }
        }
        return false;
    }

    //extracts data from db and stores it in list called deserialized data
    void dbExtractor()
    {
        reference.Child("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                var data = snapshot.GetRawJsonValue();
                deserializedData = JsonConvert.DeserializeObject<List<usersDetails>>(data);
            }
            else
            {
                Debug.Log("error");
            }

        });
    }
}
