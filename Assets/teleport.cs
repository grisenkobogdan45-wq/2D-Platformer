using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class teleport : scene_open
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string lvlToOpen;
    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(lvlToOpen);
    }
}
