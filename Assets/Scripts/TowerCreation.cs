using UnityEngine;
using System.Collections.Generic;

public class TowerCreation : MonoBehaviour {

	public GameObject row;
	[Range(10, 20)]
	public int noOfRows = 11;

	public float startFixedY = -2.5f;

	float startingY;

	List<GameObject> rows;

	// Use this for initialization
	void Start () {
		startingY = startFixedY;
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
			tmp.name = "Row#" + (i + 1);
		}
	}

	public void RecreateTower() 
	{
		print("[Tower] recreating!");

		for (int i = 0; i < rows.Count; i++)
		{
			DestroyImmediate(rows[i]);
		}

		startingY = startFixedY;

		CreateTower();
	}
}
