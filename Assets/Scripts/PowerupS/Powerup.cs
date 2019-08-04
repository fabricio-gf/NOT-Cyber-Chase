using UnityEngine;

public class Powerup : MonoBehaviour
{
    float angularVelocity;
    public float maxVelocity;
    public float minVelocity;

    public float moveSpeed;

    public PowerupType myType;

    public enum PowerupType
    {
        SHOT,
        SHIELD,
        BOMB,
        LIFE
    }

    Transform child;    

    public void Awake()
    {
        angularVelocity = Random.Range(minVelocity, maxVelocity);
        if(Random.value >= 0.5f)
        {
            angularVelocity = -angularVelocity;
        }
        child = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        child.Rotate(new Vector3(0, 0, 1), angularVelocity);
        transform.Translate(Vector3.down*moveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.tag);
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
            Destroy(gameObject);
        }
    }
}
