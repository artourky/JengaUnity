using UnityEngine;

public class Logic : MonoBehaviour {

	TowerCreation towerObj;

	void Start()
	{
		print("[Logic] Press 'r' to reload Scene, 'c' to recreate Tower!");

		if (towerObj == null)
		{
			towerObj = GetComponent<TowerCreation>();
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			RestartLevel();
		}

		if (Input.GetKeyDown(KeyCode.C))
		{
			RecreateTower();
		}
	}

	public void RestartLevel()
	{
		print("[Logic] Resarting Game");
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}

	public void RecreateTower()
	{
		print("[Logic] recreating Tower");
		towerObj.RecreateTower();
	}
}
