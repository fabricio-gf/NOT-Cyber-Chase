using UnityEngine;
using Mirror;

public class NetworkPlayer : NetworkBehaviour
{

    float speed = 1f;

    void Update()
    {
        if (!isLocalPlayer)
        {
            // exit from update if this is not the local player
            return;
        }

        // handle player input for movement
        if(Input.GetKey(KeyCode.W)){
            Vector3 p = transform.position;
            p.y+= speed * Time.deltaTime;
            transform.position = p;
        }
        if(Input.GetKey(KeyCode.S)){
            Vector3 p = transform.position;
            p.y-= speed * Time.deltaTime;
            transform.position = p;
        }
    }
}
