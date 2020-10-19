using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Player Hud")]
    public int PlayerScore = 0;
    public Text ScoreText;
    public int PlayerLives = 3;
    public float GameTime;
    public float GameSpeed = 1f;
    public Text GameTimeText;
    public Text CountdownText;

    [Header("Ghosts")]
    public Text GhostTimerText;
    public GhostController[] Ghosts;

    [Header("Audio")]
    public AudioClip BackgroundClip;
    public AudioClip GhostScaredClip;
    public AudioSource MusicSource;


    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 0f;
        ScoreText.text = "Score: " + PlayerScore;
        StartCountdown();
    }

    // Update is called once per frame
    void Update()
    {
        //Not entirely sure why it starts at 00:00:02 my guess is that theres some time before it starts
        // and the time scale is set to 0
        GameTime += Time.deltaTime * GameSpeed;
        GameTimeText.text = TimeSpan.FromSeconds(GameTime).ToString("mm\\:ss\\:ff");
    }

    public void AddToScore(int amount) {
        PlayerScore += amount;
        ScoreText.text = "Score: " + PlayerScore;
    }

    public void StartCountdown() {
        //needs to be .5 because otherwise itll show 2 at the start rather than 3
        StartCoroutine(Countdown(3.5f));

    }

    //When a pellet is eaten then set each of the ghosts to be scared
    public void PowerPelletEaten() {

        StartCoroutine(GhostTimer(10.5f));
    }

    public void RemoveLife() {
        PlayerLives--;
        if(PlayerLives == 0) {
            //Game over
        }
        else {
            //Remove a life heart from the bar
        }
    }
    private IEnumerator GhostTimer(float amount) {
        Debug.Log("Ghost Timer Started");
        MusicSource.clip = GhostScaredClip;
        MusicSource.Play();
        float time = amount;
        GhostTimerText.gameObject.SetActive(true);
        //Set them to scared
        foreach (GhostController ghost in Ghosts) {
            ghost.SetState(2);
        }

        while (time > 1) {
            time -= Time.deltaTime;
            GhostTimerText.text = "Ghost Timer: " + Mathf.FloorToInt(time).ToString();
            yield return null;
        }
        //Need to set them to recovering a some point

        //Set them to normal
        foreach (GhostController ghost in Ghosts) {
            ghost.SetState(1);
        }
        GhostTimerText.enabled = false;
        MusicSource.clip = BackgroundClip;
        MusicSource.Play();
        Debug.Log("Ghost Timer Done");

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
