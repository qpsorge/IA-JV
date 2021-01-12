using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioPreGame : MonoBehaviour
{
    public Text m_text;
    public GameObject m_game;
    private int step = 0;
    private string[] texts;
    // Start is called before the first frame update
    void Start()
    {
        texts = new string[] {
            "You are the proud prince Hugo! ",
            "Your princess Sebastiannette has been kidnapped by the venimous Egyptian Spider Nitneuq..",
            "...You must save her from this danger, and bring her back to your kingdom !",
            "You succeeded in finding where your beloved was kept.",
            "However, the Egyptian Spider Nitneuq is smart : she has a guard watching the door !",
            "Your first mission, if you accept it, is to cross the checkpoint kept by this very threatening guard ! Only then, you will be able to defeat the evil Nitneuq to rescue your cherished darling ;)"
        };
    }

    // Update is called once per frame
    void Update()
    {
        m_text.text = texts[step];
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (step == 5)
            {
                m_game.SetActive(true);
                gameObject.SetActive(false);
            }
                
            else
                step++;
        }
    }
}
