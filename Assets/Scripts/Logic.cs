using UnityEngine;

public class Logic : MonoBehaviour {

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			print("[Logic] Resarting Game");
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}
	}

}
