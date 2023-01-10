using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChestDropper : MonoBehaviour
{
    public GameObject chest;
    List<Hints> hints;
    public static int hintsNo = 0;
    public static int keys = 0;
    bool initiated = false;
    GameObject game;


    // Start is called before the first frame update
    void Start()
    {
        hints = MenuUIScripts.userHints;
    }

    // Update is called once per frame
    void Update()
    {
        // hintsNo++;
        // Debug.Log(hintsNo);
        spawnCube();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            initiated = false;
        }

    }
    void spawnCube()
    {

        if (!initiated)
        {
            Destroy(GameObject.FindWithTag("chest"));
            Debug.Log(initiated + " hints no is " + hintsNo);
            hintsNo++;
            initiated = true;
            game = Instantiate(chest, new Vector3(0f, 4f, 0f), new Quaternion(-0.707f, -0.707f, -0.707f, 0.707f));
            game.GetComponentInChildren<TMP_Text>().text = hints[hintsNo].clue;
        }
    }
}
