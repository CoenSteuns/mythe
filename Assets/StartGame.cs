using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public ResetWorld _reset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(Input.GetAxisRaw("Jump"));
        if(Input.GetAxisRaw("Jump") == 1)
        {
            print("asdasdasd");
            Time.timeScale = 1;
            _reset.ResetAll();
        }

    }
}
