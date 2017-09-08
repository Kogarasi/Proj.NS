using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS.Model {
	public class PrefabCacheModel : Sparrow.Model<PrefabCacheModel> {
		Dictionary<string, GameObject> dictionary = new Dictionary<string, GameObject>();

		public GameObject get( string prefabName ){
			if( dictionary.ContainsKey(prefabName)){
				return dictionary[ prefabName ];
			} else {
				var resource = Resources.Load( prefabName ) as GameObject;
				if( resource == null ){
					throw new Exception( "Failed load resource!!" );
				}
				
				dictionary.Add( prefabName, resource );
				return resource;
			}
		}
	}
}