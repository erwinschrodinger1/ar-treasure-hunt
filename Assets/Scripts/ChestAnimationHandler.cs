using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestAnimationHandler : MonoBehaviour
{
    private Animation anime;
    // Start is called before the first frame update
    void Start()
    {
        anime = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    if (hit.transform.tag == "chest")
                    {
                        anime.Play("Armature.002|ArmatureAction.001");
                        if (!MenuUIScripts.userHints[ChestDropper.hintsNo].completed)
                        {
                            MenuUIScripts.userHints[ChestDropper.hintsNo].completed = true;
                            ChestDropper.keys++;
                        }
                    }

                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider != null)
                {
                    if (hit.transform.tag == "chest")
                    {
                        anime.Play("Armature.002|ArmatureAction.001");
                        if (!MenuUIScripts.userHints[ChestDropper.hintsNo].completed)
                        {
                            MenuUIScripts.userHints[ChestDropper.hintsNo].completed = true;
                            ChestDropper.keys++;
                            Debug.Log("key is " + ChestDropper.keys);
                        }
                    }

                }
            }
        }
    }
}
