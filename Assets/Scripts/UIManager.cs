using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text player1ScoreText;
    public Text player2ScoreText;


    void Start()
    {
        ChangeScore();
    }


    void ChangeScore()
    {
        if (player1ScoreText != null)
            player1ScoreText.text = ScoreManager.instance.player1.ToString();
        if(player2ScoreText!=null)
            player2ScoreText.text = ScoreManager.instance.player2.ToString();
    }
}
