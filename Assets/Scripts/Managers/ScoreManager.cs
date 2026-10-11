using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    // Hỗ trợ cả 2 loại Text: TMP (Unity 6) và Legacy
    TextMeshProUGUI tmpText;
    Text legacyText;


    void Awake ()
    {
        tmpText = GetComponent <TextMeshProUGUI> ();
        legacyText = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        if (tmpText != null)
        {
            tmpText.text = "Score: " + score;
        }
        else if (legacyText != null)
        {
            legacyText.text = "Score: " + score;
        }
    }
}
