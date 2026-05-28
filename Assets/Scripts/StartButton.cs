using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool touch = false;
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touch = true;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            touch = true;
        }
        if (touch)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}