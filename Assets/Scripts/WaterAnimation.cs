using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimation : MonoBehaviour {
	public float scrollSpeed = 0.5f;
	private float offset;
	public Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex",new Vector2(offset,offset));
		rend.material.SetTextureOffset("_BumpMap",new Vector2(offset,offset));
	}
}
