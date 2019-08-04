using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerCOntroller : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.GetPlayerInput(0) != null) {
            Vector3 pos = transform.position;
            pos.x += InputManager.GetPlayerInput(0).GetHorizontal();
            pos.y += InputManager.GetPlayerInput(0).GetVertical();
            transform.position = pos;
        }
       
    }
}
