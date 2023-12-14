using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class URL : MonoBehaviour
{
    public string url;
    // Start is called before the first frame update
    // will open a webpage link
    public void OpenGithub()
    {
        Application.OpenURL(url);
    }
}
