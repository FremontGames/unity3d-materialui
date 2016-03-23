using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Builder
{
	public static GameObject build(Transform parent, int layer, string name) {
		GameObject obj = new GameObject (name);
		obj.transform.SetParent (parent);
		obj.layer = layer;
		return obj;
	}

}

