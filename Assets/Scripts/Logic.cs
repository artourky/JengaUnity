using UnityEngine;

public class Logic : MonoBehaviour {

	public Transform cameraHolder;

	TowerCreation towerObj;

	void Start()
	{
		print("[Logic] Press 'r' to reload Scene, 'c' to recreate Tower, 'x' to explode!");

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

		if (Input.GetKeyDown(KeyCode.X))
		{
			Explode();
		}
	}

	public void Explode()
	{
		print("[Logic] Appling Explosing force!");
		towerObj.MakeExplosion();
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

	public void RaiseCameraHolder()
	{
		cameraHolder.localPosition = cameraHolder.localPosition + new Vector3(0f, 1f);
	}
}
