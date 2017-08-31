using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Binding;
using Sparrow.Interface;
using Sparrow.Rx;

namespace NS.Model {
	public class BulletModel : Sparrow.Model<BulletModel>, Updatable {
		
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
				return true;
			}).ToList();
		}

		View.BulletView createView( Bullet.BulletBase bullet, Vector2 position ){
			var prefab = getPrefabFromAttribute( bullet );
			var go = (GameObject.Instantiate( prefab ) as GameObject);
			var view = go.GetComponent<View.BulletView>();

			go.transform.localPosition = new Vector3( position.x, position.y, 0 );

			return view;
		}
	}
}