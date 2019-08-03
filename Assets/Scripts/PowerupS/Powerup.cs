using UnityEngine;

public class Powerup : MonoBehaviour
{
    float angularVelocity;
    public float maxVelocity;
    public float minVelocity;

    public PowerupType myType;

    public enum PowerupType
    {
        SHOT,
        SHIELD,
        BOMB,
        LIFE
    }

    public void Awake()
    {
        angularVelocity = Random.Range(minVelocity, maxVelocity);
        if(Random.value >= 0.5f)
        {
            angularVelocity = -angularVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), angularVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player pl = collision.GetComponent<Player>();
            switch (myType)
            {
                case PowerupType.SHOT:
                    pl.IncrementShotLevel();
                break;
                case PowerupType.SHIELD:
                    pl.AddShield();
                break;
                case PowerupType.BOMB:
                    pl.AddBomb();
                break;
                case PowerupType.LIFE:
                    pl.AddLife();
                break;
            }
        }
    }
}
