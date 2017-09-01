using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NS.Model {
	public class BulletCacheModel : Sparrow.Model<BulletCacheModel> {
		Dictionary<Type, List<View.BulletView>> cacheData = new Dictionary<Type, List<View.BulletView>>();

		public View.BulletView pop( Type viewType ){
			if( !cacheData.ContainsKey(viewType) ){
				return null;
			}

			if( cacheData[ viewType ].Any() ){
				var obj = cacheData[ viewType ][0];
				cacheData[ viewType ].RemoveAt(0);

				obj.gameObject.SetActive( true );
				return obj;
			} else {
				return null;
			}
		}

		public void push( View.BulletView view ){
			view.gameObject.SetActive( false );

			var viewType = view.GetType();
			if( !cacheData.ContainsKey( viewType ) ){
				cacheData[ viewType ] = new List<View.BulletView>();
			}

			cacheData[ viewType ].Add( view );
		}
	}
}