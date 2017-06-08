using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    public GameObject Gameover;

	public void Die()
    {
        Gameover.SetActive(true);
        Time.timeScale = 0;
    }
}
