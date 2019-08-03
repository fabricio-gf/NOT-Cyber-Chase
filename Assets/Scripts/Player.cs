using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Parameters")]
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
    public GameObject shotPrefab;
    public GameObject shieldPrefab;
    public GameObject bombPrefab;

    [System.Serializable] public struct ShotFormation
    {
        public Vector3[] positions;
        public Vector3[] directions;
    }

    public void IncrementShotLevel()
    {
        if (shotLevel < maxShotLevel)
        {
            shotLevel++;
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
            //spawnshield
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
            //destroyShield 
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

    public void AddLife()
    {
        if(lives < maxLives)
        {
            lives++;
        }
        else
        {
            //addmorepoints
        }
    }
}
