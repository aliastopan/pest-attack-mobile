using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
  public static readonly int[] MAX_ENEMY = new int[] { 7, 15, 17, 22, 25};
  public static readonly int STAGE_1_MAX_ENEMY = 7;
  public static readonly int STAGE_2_MAX_ENEMY = 15;
  public static readonly int STAGE_3_MAX_ENEMY = 17;
  public static readonly int STAGE_4_MAX_ENEMY = 22;
  public static readonly int STAGE_5_MAX_ENEMY = 25;

  public static int currentEnemy = 0;


}
