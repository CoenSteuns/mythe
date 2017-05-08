using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOver : MonoBehaviour {

    public GameObject gameover;
    public float respawnTime;

    public Transform spawn;
    public GameObject player;

    public UnityEvent e;

    private void Start()
    {
        gameover.SetActive(false);
        player.transform.position = spawn.position;
    }

    public void Gameover()
    {
        Time.timeScale = 0;
        gameover.SetActive(true);
        StartCoroutine(Restart());
    }


    private IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(respawnTime);
        Time.timeScale = 1;
        gameover.SetActive(false);
        player.transform.position = spawn.position;
        e.Invoke();
    }
}
