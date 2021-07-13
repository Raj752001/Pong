using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int player1=0;
    public int player2=0;
    public AudioClip explosion;

    Transform ballT;
    float widthLimit;

    public static ScoreManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            AudioSource.PlayClipAtPoint(explosion, Vector3.zero);
            DestroyImmediate(this);
        }
        else {
            instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(transform);
        widthLimit = Camera.main.aspect * Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadGame();
        }
        if(ballT!= null)
        {
            if (ballT.position.x > widthLimit)
            {
                player1++;
                LoadGame();
                
            }
            if (ballT.position.x < -widthLimit)
            {              
                player2++;
                LoadGame();
            }
        }
        else
        {
            ballT = FindObjectOfType<Ball>().transform;
        }
        
    }

    void LoadGame() {
        SceneManager.LoadScene("Game");
    }
}
