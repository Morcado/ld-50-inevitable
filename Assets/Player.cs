using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    List<string> colors = new List<string>();
    public string selectdColor;
    public bool userHasTrueKey = false;
    public bool userHasFalseKey = false;
    public bool keyIsInserted = false;
    public TextMeshProUGUI book1Text;
    public TextMeshProUGUI book2Text;
    public TextMeshProUGUI deactivateBombText;
    public TextMeshProUGUI button1BombText;
    public TextMeshProUGUI button2BombText;
    public TextMeshProUGUI button3BombText;
    public TextMeshProUGUI helpText;
    public Button trapdoorKeyButton;

    public Image trueKey;
    public Image falseKey;

    public GameObject SecretKey;
    public GameObject DeactivateBomb;
    // Start is called before the first frame update
    void Start()
    {
        colors.Add("red");
        colors.Add("green");
        colors.Add("blue");

        Shuffle(colors);

        selectdColor = colors[Random.Range(0, 3)];

        book1Text.text = book1Text.text.Replace("{random}", selectdColor);

        book2Text.text = book2Text.text.Replace("{random1}", colors[0]);
        book2Text.text = book2Text.text.Replace("{random2}", colors[1]);
        book2Text.text = book2Text.text.Replace("{random3}", colors[2]);

        button1BombText.text = $"Push {colors[0]} button";
        button2BombText.text = $"Push {colors[1]} button";
        button3BombText.text = $"Push {colors[2]} button";

        /*MainRoomChoices = GameObject.FindWithTag("MainRoomChoices");
        MainRoomChoices.SetActive(false);
        SecretKey = GameObject.FindWithTag("SecretKey");
        SecretKey.SetActive(false);*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickFalseKey()
    {
        userHasFalseKey = true;
        trapdoorKeyButton.gameObject.SetActive(true);
    }

    public void InsertKey()
    {
        keyIsInserted = true;
        deactivateBombText.text = deactivateBombText.text.Replace("You decide to...", "You inserted the key");
    }

    public void PickTrueKey()
    {
        userHasTrueKey = true;
        trapdoorKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Use true key";
    }

    public void PushButton(Button button)
    {
        if (button.GetComponentInChildren<TextMeshProUGUI>().text.Contains(selectdColor))
        {
            DeactivateBomb.SetActive(false);
            SecretKey.SetActive(true);
        }
        else
        {
            GameOver();
        }
    }

    public void TrapdoorUseKey()
    {
        if (userHasFalseKey && !userHasTrueKey)
        {
            helpText.gameObject.SetActive(true);
        }
       
        if (userHasTrueKey)
        {
            SceneManager.LoadScene("Win");
        }
    
    }

    private void Shuffle<T>(IList<T> ts) {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
