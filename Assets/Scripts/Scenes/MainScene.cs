using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Binding;

namespace NS.Scene {

  [ManageModel( typeof(Model.PlayerModel) )]
  [ManageModel( typeof(Model.BulletModel) )]
  [ManageModel( typeof(Model.EnemyModel) )]
  [ManageModel( typeof(Model.PrefabCacheModel) )]
  [ManageModel( typeof(Model.BulletCacheModel) )]
  public class MainScene : Sparrow.Scene<MainScene> {
    public new void Start(){
      base.Start();
      Application.targetFrameRate = 60;

      Model.EnemyModel.instance.spawn( typeof( View.Enemy.MobEnemy1View ), Vector2.zero );
    }
  }
}