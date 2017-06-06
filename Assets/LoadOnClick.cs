using UnityEngine;
using UnityEngine.SceneManagement;

namespace MDUI
{
    // https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager.LoadScene.html

    public class LoadOnClick : MonoBehaviour
    {

        public void LoadScene(string scene)
        {
            Debug.Log("scene2 loading: " + scene);
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }
}