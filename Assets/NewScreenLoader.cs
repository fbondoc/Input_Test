using UnityEngine;
using UnityEngine.SceneManagement;
public class NewScreenLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    [SerializeField] string sceneToLoad;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
