using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class Score : MonoBehaviour {

    static public Score S;
     public int score;
    public Text scoreText;
    void Awake()
    {
        S = this;
    }
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Your Score: " + score;
	}
}
