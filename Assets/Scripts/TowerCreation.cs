using UnityEngine;
using System.Collections.Generic;

public class TowerCreation : MonoBehaviour {

	public GameObject row;
	[Range(10, 20)]
	public int noOfRows = 11;

	public float fixedStartedY = -2.5f;

	[Space(20)]
	public float explosionForce = 1000f;

	float startingY;

	List<GameObject> rows;

	Logic logicObj;

	// Use this for initialization
	void Start () {
		if (logicObj == null)
		{
			logicObj = GetComponent<Logic>();
		}

		startingY = fixedStartedY;
		rows = new List<GameObject>(noOfRows);
		CreateTower();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CreateTower() 
	{
		print("[Tower] Creating!");

		for (int i = 0; i < noOfRows; i++)
		{
			GameObject tmp = Instantiate(row, Vector3.zero, (i % 2 == 0) ? Quaternion.identity : Quaternion.Euler(0f, 90f, 0f), transform);
			tmp.transform.localPosition = new Vector3(0, startingY++);
			if (startingY >= 7.5f)
			{
				logicObj.RaiseCameraHolder();
			}
			tmp.name = "Row#" + (i + 1);
			rows.Add(tmp);
		}
	}

	public void RecreateTower() 
	{
		print("[Tower] recreating!");

		for (int i = 0; i < rows.Count; i++)
		{
			DestroyImmediate(rows[i]);
		}

		rows.Clear();

		startingY = fixedStartedY;

		CreateTower();
	}

	public void MakeExplosion()
	{
		for (int i = 0; i < rows.Count; i++)
		{
			rows[i].GetComponentsInChildren<Rigidbody>()[0].AddExplosionForce(explosionForce, transform.position, explosionForce, 1f);
			rows[i].GetComponentsInChildren<Rigidbody>()[1].AddExplosionForce(explosionForce, transform.position, explosionForce, 1f);
			rows[i].GetComponentsInChildren<Rigidbody>()[2].AddExplosionForce(explosionForce, transform.position, explosionForce, 1f);
		}
	}
}
