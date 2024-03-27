using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {
	

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
	public void InputName()
    {
        SceneManager.LoadScene("InputName");
    }
	public void MainManu()
    {
        SceneManager.LoadScene("MainManu");
    }
	public void Playscene()
    {
        SceneManager.LoadScene("Playscene");
    }
	public void Helper()
    {
        SceneManager.LoadScene("Helper");
    }
}
