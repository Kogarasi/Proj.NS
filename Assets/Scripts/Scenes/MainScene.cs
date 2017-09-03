using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Binding;

namespace NS.Scene {

  [ManageModel( typeof(Model.PlayerModel) )]
  [ManageModel( typeof(Model.BulletModel) )]
  [ManageModel( typeof(Model.PrefabCacheModel<GameObject>) )]
  [ManageModel( typeof(Model.BulletCacheModel) )]
  public class MainScene : Sparrow.Scene<MainScene> {
    public new void Start(){
      base.Start();
      Application.targetFrameRate = 60;
    }
  }
}