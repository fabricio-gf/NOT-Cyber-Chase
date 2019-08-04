using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInvincibility : MonoBehaviour
{
    public float totalDuration;

    BoxCollider2D coll;
    SpriteRenderer sprite;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>();
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void Toggle()
    {
        StartCoroutine(FlashSprite());
    }

    IEnumerator FlashSprite()
    {
        coll.enabled = false;
        sprite.enabled = false;

        yield return new WaitForSeconds(totalDuration / 10);

        sprite.enabled = true;

        yield return new WaitForSeconds(2*totalDuration / 10);

        sprite.enabled = false;

        yield return new WaitForSeconds(totalDuration / 10);

        sprite.enabled = true;

        yield return new WaitForSeconds(2*totalDuration / 10);

        sprite.enabled = false;

        yield return new WaitForSeconds(totalDuration / 10);

        sprite.enabled = true;

        yield return new WaitForSeconds(2 * totalDuration / 10);

        sprite.enabled = false;

        yield return new WaitForSeconds(totalDuration / 10);

        sprite.enabled = true;
        coll.enabled = false;
        GetComponent<AutoShoot>().canShoot = true;
    }
}
