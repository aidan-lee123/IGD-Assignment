using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int PlayerScore = 0;
    public Text ScoreText;
    public int PlayerLives = 3;
    public Time GameTime { get; set; }

    public Text CountdownText;



    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 0f;
        ScoreText.text = "Score: " + PlayerScore;
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int amount) {
        PlayerScore += amount;
        ScoreText.text = "Score: " + PlayerScore;
    }

    public void StartCountdown() {
        StartCoroutine(Countdown(3.5f));

    }

    private IEnumerator Countdown(float amount) {

        float time = amount;

        while(time > 1) {
            time -= Time.unscaledDeltaTime;
            CountdownText.text = Mathf.FloorToInt(time).ToString();
            yield return null;
        }
        Time.timeScale = 1f;
        CountdownText.text = "GO!";
        yield return new WaitForSeconds(1);
        CountdownText.enabled = false;
    }
}
