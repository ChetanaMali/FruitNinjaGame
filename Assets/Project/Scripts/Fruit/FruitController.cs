using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    [SerializeField] GameObject[] fruits;
    [SerializeField] GameObject bomb;
    [SerializeField] float force;
    [SerializeField] int maxX, minX;
    [SerializeField] float fruitSpawnPositionY;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] float fruitDelayTime = 2;
    [SerializeField] float bombDelayTime = 5;
    [SerializeField] GameObject triggerBox;
    bool isGameOver;
    int score;
    [SerializeField] TMPro.TextMeshProUGUI scoreText, finalScoreText;
    private void Start()
    {
        StartCoroutine(SpawnFruits());
        StartCoroutine(SpawnBombAfterDelay());
        GameOverScreen.SetActive(false);
        SoundController.Instance.GameStartPlay();
    }
    private void OnEnable()
    {
        GameEvent.GameOver += GameOver;
        GameEvent.Score += Score;
    }
    private void OnDisable()
    {
        GameEvent.GameOver -= GameOver;
        GameEvent.Score -= Score;
    }
    float n = 0, SpeedIncreaseTime = 10;
    private void Update()
    {
        IncreaseDeylayTimeOfSpawnfruit();
     
    }
    void IncreaseDeylayTimeOfSpawnfruit()
    {
        n += Time.deltaTime;
        if (n >= SpeedIncreaseTime)
        {
            if (fruitDelayTime >= 0.5f)
            {
                fruitDelayTime -= 0.1f;
                n = 0;
            }

        }
    }
    void Score()
    {
        score++;
        scoreText.text = score.ToString();
    }
    void GameOver()
    {
        isGameOver = true;      // after triggering this true the fruits will stop to spwan 
        force = 0;
        GameOverScreen.SetActive(true);
        finalScoreText.text = score.ToString();
        SoundController.Instance.GameOverPlay();
        triggerBox.SetActive(false);
    }
    void SpawnAndAddForceToFruit()
    {

        int randomFruitnumber = UnityEngine.Random.Range(0, fruits.Length);
        int randomX = UnityEngine.Random.Range(minX, maxX);
        GameObject randomFruit = Instantiate(fruits[randomFruitnumber], new Vector3(randomX, fruitSpawnPositionY, 0), fruits[randomFruitnumber].transform.rotation);
        randomFruit.GetComponent<Rigidbody>().AddForce(RandomDirection() * Force(), ForceMode.Impulse);
        randomFruit.transform.rotation = UnityEngine.Random.rotation;

        SoundController.Instance.FruitThrowPlay();
    }
    float Force()
    {
        int minForce = 15, maxForce = 17;
        force = UnityEngine.Random.Range(minForce, maxForce);
        return force;
    }
    float left = -0.2f, right = 0.1f;
    Vector2 RandomDirection()
    {
        
        Vector2 movedirection = new Vector2(UnityEngine.Random.Range(left, right), 1).normalized;
        return movedirection;
    }
    IEnumerator SpawnFruits()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(fruitDelayTime);
            SpawnAndAddForceToFruit();
        }
    }
    void SpawnBomb()
    {
        int randomX = UnityEngine.Random.Range(minX, maxX);
        GameObject spawnBomb = Instantiate(bomb, new Vector3(randomX, fruitSpawnPositionY, 0), bomb.transform.rotation);
        spawnBomb.GetComponent<Rigidbody>().AddForce(Vector2.up * force, ForceMode.Impulse);

        SoundController.Instance.BombThrowPlay();
    }
    IEnumerator SpawnBombAfterDelay()
    {
        while (!isGameOver)
        {
            int min = 5, max = 10;
            bombDelayTime = UnityEngine.Random.Range(min, max);
            yield return new WaitForSeconds(bombDelayTime);
            SpawnBomb();
        }
    }
}
