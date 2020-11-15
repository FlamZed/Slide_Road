using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;

    [SerializeField] private static UiContainer uiContainer;

    private float xMin = 0.5f;
    private float xMax = 3.5f;
    [SerializeField] private float sensitive = 6f;

    private float startPoint;
    private  float localX;
    private  float globalX;
    private  float temp = 0f;

    private static bool isStart;

    void Start()
    {
        uiContainer = GameObject.Find("Canvas").GetComponent<UiContainer>();
        localX = Mathf.Abs(left.localPosition.x);
        Time.timeScale = 0;
        isStart = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && isStart)
        {
            var mousePos = new Vector3(Input.mousePosition.x, 0, 10);
            var objPosition = Camera.main.ScreenToWorldPoint(mousePos);

            globalX = -(objPosition.x - startPoint);

            if (startPoint == 0)
            {
                startPoint = objPosition.x;
            }
            else if (startPoint != objPosition.x)
            { 
                if (globalX == temp)
                    startPoint = objPosition.x;
                else
                    MovePlayer(globalX);
                temp = globalX;
            }
        }

        if(Input.GetMouseButtonUp(0) && isStart)
        {
            startPoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= -2f)
        {
            Lose();
        }
    }

    private void MovePlayer(float axisX)
    {
        localX = Mathf.Clamp(localX - axisX / sensitive, xMin, xMax);

        left.localPosition = new Vector3(-localX, 0);
        right.localPosition = new Vector3(localX, 0);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        isStart = true;
    }

    public static void Lose()
    {
        Time.timeScale = 0;
        uiContainer.LousePanel();
        isStart = false;
    }

    public static void Win()
    {
        Time.timeScale = 0;
        uiContainer.WinPanel();
        isStart = false;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}