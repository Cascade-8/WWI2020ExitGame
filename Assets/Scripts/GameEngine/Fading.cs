using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameEngine
{
    public class Fading : MonoBehaviour
    {
        public void OnFadeComplete()
        {
            SceneManager.LoadScene("OutroVideo");
        }
    }
}
