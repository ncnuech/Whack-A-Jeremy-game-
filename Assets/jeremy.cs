using UnityEngine;
using System.Collections;

public class jeremy : MonoBehaviour {

    private SpriteRenderer m_spriteRenderer;
    public bool isInCycle;
    public float appear;
    public float stay;
    public float startTime;
    public int score = 0;
    public Sprite bond;
    public Sprite tigger;
    public Sprite pikachu;
    // Use this for initialization
    void Start () {
        m_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        m_spriteRenderer.enabled = false;	
	}

    bool isAbove()
    {
        return m_spriteRenderer.enabled;
    }

    void FixedUpdate()
    {

    }

    void startCycle()
    {
        int character = Random.Range(1,100);
        if (character < 75)
        {
            m_spriteRenderer.sprite = bond;
        }
        else if (character  >= 75 && character < 87)
        {
            m_spriteRenderer.sprite = tigger;
        }
        else if (character >= 87)
        {
            m_spriteRenderer.sprite = pikachu;
        }

        appear = Random.Range(2, 4);    // time in between jeremy appearances
        stay = Random.Range(2, 4);  // number of seconds jeremy will stay above ground before he is hit


        startTime = Time.time;
        isInCycle = true;
    }





	// Update is called once per frame
	void Update () {
        if (!isInCycle)
        {
            startCycle();
        }
        if (!isAbove())
        {
            if (Time.time - startTime > appear) // time for jeremy to appear
            {
                m_spriteRenderer.enabled = true;
                startTime = Time.time;
            }
        }
        else
        {
            if (Time.time - startTime > stay)
            {
                m_spriteRenderer.enabled = false;
                isInCycle = false;
            }
        }

    }

    void OnMouseDown()
    {
        if (isAbove())
        {
            if (m_spriteRenderer.sprite == bond)
            {
                print("clicked Jeremy!");
                GameObject go = GameObject.Instantiate(Main.S.posMessagePrefab);
                StartCoroutine("raiseMessage", go);
                Score.S.score += 1;
            }
            else
            {
                print("you killed the good guys :(");
                Score.S.score -= 5;
            }

            print("your score: " + Score.S.score);
        }
    }

    IEnumerator raiseMessage(GameObject go)
    {
        Vector2 newPos = Input.mousePosition;
        newPos.y += 100;
        go.transform.position = newPos;
        yield return new WaitForSeconds(2);
        Destroy(go);
    }

}
