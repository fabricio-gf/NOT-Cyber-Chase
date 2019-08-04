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
            Destroy(collision.gameObject);
            if(lives > 0)
            {
                lives--;
            }
            else
            {
                if(collision.gameObject != null)
                    PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("KillSimpleEnemy"), collision.GetComponent<ProjectileBehaviour>().myShooter.GetComponent<Player>().playerNumber);
                ExplosionSpawner.instance.SpawnExplosion(transform.position);
                PowerupSpawner.instance.CheckPowerupSpawn(transform.position);
                Destroy(gameObject);
            }
        }
    }
}
