using UnityEngine;
using System.Collections;

public class BUI
{
	Transform _parent;

	public BUI(params BUI[] childs){
//		_childs = childs;
	}

	public BUI(Transform parent, params BUI[] childs){
		_parent = parent;
//		_childs = childs;
	}

}

