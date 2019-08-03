using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Parameters")]
    [Range(1,4)]public int playerNumber;

    [Space(10)]
    public int shotLevel;
    public int maxShotLevel;
    [Space(10)]
    public ShotFormation[] formations;

    [Space(20)]
    public bool hasShield;

    [Space(20)]
    public int bombs;
    public int maxBombs;

    [Space(20)]
    public int lives;
    public int maxLives;

    [Header("References")]
    public GameObject shieldObject;
    public GameObject bombPrefab;

    [System.Serializable] public struct ShotFormation
    {
        public Vector3[] positions;
        public Vector3[] velocities;
    }

    public void IncrementShotLevel()
    {
        if (shotLevel < maxShotLevel)
        {
            shotLevel++;
            GetComponent<AutoShoot>().ChangeFormation(formations[shotLevel]);
        }
        else
        {
            //addmorepoints
        }
    }

    public void AddShield()
    {
        if (!hasShield)
        {
            shieldObject.SetActive(true);
            //play sfx
        }
        else
        {
            //addmorepoints
        }
    }

    public void AddLife()
    {
        if (lives < maxLives)
        {
            lives++;
        }
        else
        {
            //addmorepoints
        }
    }

    public void TakeDamage()
    {
        if (hasShield)
        {
            shieldObject.SetActive(false);
            //play sfx
        }
        else
        {
            if(lives > 1)
            {
                lives--;
                //update UI
            }
            else
            {
                //spawn explosion
                //update UI
                //request new spawn
                Destroy(gameObject);
            }
        }
    }

    public void AddBomb()
    {
        if (bombs < maxBombs)
        {
            bombs++;
        }
        else
        {
            //addmorepoints
        }
    }

    public void UseBomb()
    {
        if (bombs > 0)
        {
            bombs--;
            //use bomb
        }
        else
        {
            //play no bomb sfx
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
}
