using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Binding;
using Sparrow.Interface;
using Sparrow.Rx;

namespace NS.Model {
	public class BulletModel : Sparrow.Model<BulletModel>, Updatable {
		Model.PrefabCacheModel prefabCacheModel = Model.PrefabCacheModel.instance;
		Model.BulletCacheModel bulletCacheModel = Model.BulletCacheModel.instance;
		List<View.Bullet.BulletView> bullets = new List<View.Bullet.BulletView>();
	
		public void emit( Type bulletType, Vector2 position ){
			var view = createView( bulletType, position );
			bullets.Add( view );
		}

		public void update(){
			bullets = bullets.Where((bullet)=>{
				bullet.move();
				if( bullet.isDirty() ){
					bulletCacheModel.push( bullet );
					return false;
				}
				return true;
			}).ToList();
		}

		View.Bullet.BulletView createView( Type type, Vector2 position ){

			var view = bulletCacheModel.pop( type );
			if( view == null ){

				var path = getPrefabPathFromAttribute( type );
				var prefab = prefabCacheModel.get(path);
				var go = GameObject.Instantiate( prefab, View.Container.BulletContainerView.instance.transform, false ) as GameObject;
				view = go.GetComponent<View.Bullet.BulletView>();
			}

			view.transform.localPosition = new Vector3( position.x, position.y, 0 );

			return view;
		}
	}
}