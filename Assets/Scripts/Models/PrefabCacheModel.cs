using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS.Model {
	public class PrefabCacheModel<T> : Sparrow.Model<PrefabCacheModel<T>> where T: UnityEngine.Object {
		Dictionary<string, T> dictionary = new Dictionary<string, T>();

		public T get( string prefabName ){
			if( dictionary.ContainsKey(prefabName)){
				return dictionary[ prefabName ];
			} else {
				var resource = Resources.Load( prefabName ) as T;
				dictionary.Add( prefabName, resource );
				return resource;
			}
		}
	}
}