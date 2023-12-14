using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Opening : MonoBehaviour
{
    public TextMeshProUGUI instructions;
    public Button start;
    public Button instructionsB;
    public Button back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Instructions()
    {
        start.gameObject.SetActive(false);
        instructionsB.gameObject.SetActive(false);
        instructions.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
    }
    public void Back()
    {
        start.gameObject.SetActive(true);
        instructionsB.gameObject.SetActive(true);
        instructions.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
    }
}
