using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RanPatrol : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float secondsToMaxDif;

    public float minSpeed;
    public float maxSpeed;
    public float speed;

    private Vector2 targetPosition;

    public GameObject restartPanel;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Vector2)transform.position != targetPosition)
        {
            speed = Mathf.Lerp(minSpeed, maxSpeed, getDifficultyPercent());
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            targetPosition = GetRandomPosition();
        }

    }

    Vector2 GetRandomPosition()
    {
        float ranX = Random.Range(minX, maxX);
        float ranY = Random.Range(minY, maxY);
        return new Vector2(ranX, ranY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Squares")
        {
            restartPanel.SetActive(true);
        }
    }

    private float getDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDif);
    }
}
