using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationQuitter : MonoBehaviour
{
	public static ApplicationQuitter Instance;
	private void Awake()
	{
		if(Instance)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(this);

	}
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

	}

}
