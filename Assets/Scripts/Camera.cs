using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Vector3 offset  = new Vector3(0, 0, -10);
    private GameObject _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_player)
        {
            transform.position = _player.transform.position + offset;
        }
    }
}
