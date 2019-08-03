using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float lives;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerProjectile"))
        {
            if(lives > 0)
            {
                lives--;
            }
            else
            {
                //spawn explosion
                FindObjectOfType<PowerupSpawner>().CheckPowerupSpawn(transform.position);
                Destroy(gameObject);
            }
        }
    }
}
