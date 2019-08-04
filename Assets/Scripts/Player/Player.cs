using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Parameters")]
    [Range(0,3)]public int playerNumber;

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
    SlideMovimentation movementScript;

    [System.Serializable] public struct ShotFormation
    {
        public Vector3[] positions;
        public Vector3[] velocities;
    }

    private void Awake()
    {
        movementScript = GetComponent<SlideMovimentation>();
    }

    private void Update()
    {
        GetMovementInputs();
        GetOtherInputs();

        /* Matando os player para efeito de teste
        if (Input.GetKeyDown(KeyCode.K)) {
            PlayerSpawner.instance.RespawnPlayer(playerNumber, 3);
        }*/
    }

    void GetMovementInputs()
    {
        if(InputManager.GetPlayerInput(playerNumber) != null)
        {
            if(InputManager.GetPlayerInput(playerNumber).GetHorizontal() > 0)
            {
                movementScript.moveRight();
            }
            if (InputManager.GetPlayerInput(playerNumber).GetHorizontal() < 0)
            {
                movementScript.moveLeft();
            }
            if (InputManager.GetPlayerInput(playerNumber).GetVertical() > 0)
            {
                movementScript.moveUp();
            }
            if (InputManager.GetPlayerInput(playerNumber).GetVertical() < 0)
            {
                movementScript.moveDown();
            }
        }
    }

    void GetOtherInputs()
    {
        if (InputManager.GetPlayerInput(playerNumber) != null)
        {
            if (InputManager.GetPlayerInput(playerNumber).GetConfirmation())
            {

            }
            if (InputManager.GetPlayerInput(playerNumber).GetCancel())
            {

            }
        }   
    }

    public void IncrementShotLevel()
    {
        if (shotLevel < maxShotLevel)
        {
            PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("GetShot"), playerNumber);
            shotLevel++;
            GetComponent<AutoShoot>().ChangeFormation(formations[shotLevel]);
        }
        else
        {
            PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("GetShotFull"), playerNumber);
        }
    }

    public void AddShield()
    {
        if (!hasShield)
        {
            PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("GetShield"), playerNumber);
            shieldObject.SetActive(true);
            //play sfx
        }
        else
        {
            PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("GetShieldFull"), playerNumber);
        }
    }

    public void AddLife()
    {
        if (lives < maxLives)
        {
            PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("GetLife"), playerNumber);
            lives++;
            GUIManager.instance.ChangeLife(playerNumber, lives);
        }
        else
        {
            PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("GetLifeFull"), playerNumber);
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
                GameOver.instance.LoseLife(playerNumber);
                ExplosionSpawner.instance.SpawnExplosion(transform.position);
                PlayerSpawner.instance.RespawnPlayer(playerNumber, lives);
                Destroy(gameObject);
            }
            else
            {
                ExplosionSpawner.instance.SpawnExplosion(transform.position);
                GUIManager.instance.ChangeLife(playerNumber, lives-1);
                GameOver.instance.LoseLife(playerNumber);
                GameOver.instance.CheckGameOver();
                Destroy(gameObject);
            }
        }
    }

    public void AddBomb()
    {
        if (bombs < maxBombs)
        {
            PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("GetBomb"), playerNumber);
            bombs++;
            GUIManager.instance.ChangeBombs(playerNumber, bombs);
        }
        else
        {
            PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("GetBombFull"), playerNumber);
        }
    }

    public void UseBomb()
    {
        if (bombs > 0)
        {
            PointsTracker.instance.UpdatePoints(PointsLookupTable.instance.FetchPointValue("UseBomb"), playerNumber);
            bombs--;
            //spawn bomb
            GUIManager.instance.ChangeBombs(playerNumber, bombs);
        }
        else
        {
            //play no bomb sfx
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyProjectile") || collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            if (collision.CompareTag("Enemy"))
                ExplosionSpawner.instance.SpawnExplosion(collision.transform.position);
            TakeDamage();
        }
    }
}
