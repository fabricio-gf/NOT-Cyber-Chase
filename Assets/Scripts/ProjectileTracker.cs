using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTracker : MonoBehaviour
{
    public List<GameObject> enemyBullets = new List<GameObject>();
    public List<GameObject> playerBullets = new List<GameObject>();

    public static ProjectileTracker instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
