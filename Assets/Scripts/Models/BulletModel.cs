using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Binding;
using Sparrow.Interface;
using Sparrow.Rx;

namespace NS.Model {
	public class BulletModel : Sparrow.Model<BulletModel>, Updatable {
		Model.PrefabCacheModel<GameObject> prefabCacheModel = Model.PrefabCacheModel<GameObject>.instance;
		Model.BulletCacheModel bulletCacheModel = Model.BulletCacheModel.instance;
		
		public Subject<View.BulletView> bulletViewSource = new Subject<View.BulletView>();

		List<Bullet.BulletBase> bullets = new List<Bullet.BulletBase>();
		
		public void emit( Type bulletType, Vector2 position ){
			var bullet = Activator.CreateInstance( bulletType ) as Bullet.BulletBase;
			var view = createView( bullet, position );
			bullet.setView( view );
			bullet.position = position;

			bulletViewSource.publish( view );

			bullets.Add( bullet );
		}

		public void update(){
			bullets = bullets.Where((bullet)=>{
				bullet.move();
				if( bullet.isDirty() ){
					bulletCacheModel.push( bullet.view );
					return false; // remove from list
				}
				return true;
			}).ToList();
		}

		View.BulletView createView( Bullet.BulletBase bullet, Vector2 position ){

			var view = bulletCacheModel.pop( bullet.viewType );
			if( view == null ){

				var path = getPrefabPathFromAttribute( bullet );
				var prefab = prefabCacheModel.get(path);
				var go = (GameObject.Instantiate( prefab ) as GameObject);
				view = go.GetComponent<View.BulletView>();
			}

			view.transform.localPosition = new Vector3( position.x, position.y, 0 );

			return view;
		}
	}
}