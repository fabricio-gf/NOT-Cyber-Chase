using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    [Header("Parameters")]
    public float shootRate;
    public float shootMultiplier;

    [Header("References")]
    public Vector3[] spawnPositions;
    public Vector3[] velocities;

    public GameObject bulletPrefab;

    Transform bulletsParent;

    float currentTime;

    GameObject obj;

    public bool canShoot = false;

    private void Start()
    {
        bulletsParent = GameObject.Find("_Bullets").transform;
        currentTime = shootRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (currentTime <= 0)
            {
                for (int i = 0; i < spawnPositions.Length; i++)
                {
                    obj = Instantiate(bulletPrefab, transform.position + spawnPositions[i], Quaternion.identity, bulletsParent);
                    obj.GetComponent<Rigidbody2D>().velocity = velocities[i];
                }
                currentTime = shootRate;
            }
            else
            {
                currentTime -= Time.deltaTime;
            }
        }
    }

    public void ChangeFormation(Player.ShotFormation newFormation)
    {
        spawnPositions = newFormation.positions;
        velocities = newFormation.velocities;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Gizmos.DrawWireCube(transform.position + spawnPositions[i], new Vector3(0.1f, 0.1f, 0));
        }
    }
}
