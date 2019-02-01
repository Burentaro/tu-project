using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
	public GameObject explodingObject;

	public Animator explodingAnimator;

	public void Replace()
	{
		SetMeshRenderer(false, gameObject);
		SetMeshRenderer(true, explodingObject);
		explodingAnimator.Play("Explosion");
		Destroy(gameObject, 2f);
	}

	private void Awake()
	{
		//Initialize Mesh Renderer value
		SetMeshRenderer(false, explodingObject);
	}

	private void SetMeshRenderer(bool value, GameObject target)
	{
		MeshRenderer[] meshRenderers = target.GetComponentsInChildren<MeshRenderer>();
		if (meshRenderers != null && meshRenderers.Length > 0)
		{
			foreach(MeshRenderer meshRenderer in meshRenderers)
			{
				meshRenderer.enabled = value;
			}
		}

	}

}