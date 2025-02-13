using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkPointpos;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        checkPointpos = transform.position;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }
    void Die()
    {
        StartCoroutine(RespawnPlayer(0.1f));
    }

    public void UpdateCheckPoint(Vector2 pos)
    {
        checkPointpos = pos;
    }

    IEnumerator RespawnPlayer(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkPointpos;
        spriteRenderer.enabled = true;
    }
}