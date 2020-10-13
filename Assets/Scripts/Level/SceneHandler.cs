using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneHandler : MonoBehaviour
{
    public void LoadLevel(int level) {
        SceneManager.LoadScene(level);
    }


}
