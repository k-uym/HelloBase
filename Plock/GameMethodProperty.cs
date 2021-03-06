﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plock
{
    using GameData = HelloMaze.BoardData;



    class GameMethodProperty:baseGameMethodProperty
    {
        public new static Dictionary<string, Method> getDoMethodDictionary()
        {
            Dictionary<string, Method> methodDictionary = baseGameMethodProperty.getDoMethodDictionary();
            //////////TODO:２．ゲームで使うメソッドのクラスを辞書に登録する/////////////
            methodDictionary.Add("右へ動く", new GoRight());
            methodDictionary.Add("左へ動く", new GoLeft());
            methodDictionary.Add("上へ動く", new GoUp());
            methodDictionary.Add("下へ動く", new GoDown());

            methodDictionary.Add("前へ進む", new GoStright());
            methodDictionary.Add("右を向く", new turnRight());
            methodDictionary.Add("左を向く", new turnLeft());
            //methodDictionary.Add("ゲームの初期化", new Constructor());//コンストラクタもここで宣言する
            return methodDictionary;
        }

        public class GoRight : Method    //TODO:２ゲームのメソッドに対応するクラスを作る
        {
            public override GameData execute(GameData game)
            {
                game.MoveOperation(game.controlobj, 2,0);
                return game;
            }
        }

        public class GoLeft : Method    //ゲームのメソッド
        {
            public override GameData execute(GameData game)
            {
                game.MoveOperation(game.controlobj, 3, 0);
                return game;
            }
        }

        public class GoUp : Method    //ゲームのメソッド
        {
            public override GameData execute(GameData game)
            {
                game.MoveOperation(game.controlobj, 1, 0);
                return game;
            }
        }

        public class GoDown : Method    //ゲームのメソッド
        {
            public override GameData execute(GameData game)
            {
                game.MoveOperation(game.controlobj, 4, 0);
                return game;
            }
        }

        public class GoStright : Method    //ゲームのメソッド
        {
            public override GameData execute(GameData game)
            {
                game.moveStraight();
                return game;
            }
        }

        public class turnRight : Method    //ゲームのメソッド
        {
            public override GameData execute(GameData game)
            {
                game.turnRight();
                return game;
            }
        }
        public class turnLeft : Method    //ゲームのメソッド
        {
            public override GameData execute(GameData game)
            {
                game.turnLeft();
                return game;
            }
        }

        public class Constructor : Method    //ゲームのメソッド
        {
            public override GameData execute(GameData game)//GUIのプログラムから呼ぶ場合
            {
                return new GameData();
            }

            public GameData execute()//最初の初期化
            {
                return new GameData();
            }
        }





        //////////bool値を返すメソッドも大体同じ要領で登録する/////////////
        public static Dictionary<string, IsMethod> getIsMethodDictionary()
        {
            Dictionary<string, IsMethod> methodDictionary = new Dictionary<string, IsMethod>();

            //methodDictionary.Add("xが2なら", new IsX2());
            methodDictionary.Add("上に物があるなら", new IsUpObject());
            methodDictionary.Add("下に物があるなら", new IsDownObject());
            methodDictionary.Add("右に物があるなら", new IsRightObject());
            methodDictionary.Add("左に物があるなら", new IsLeftObject());

            methodDictionary.Add("正面が壁なら", new IsUpWall());
            methodDictionary.Add("右が壁なら", new IsRightWall());
            methodDictionary.Add("左が壁なら", new IsLeftWall());
            methodDictionary.Add("正面に壁がないなら", new IsntUpWall());
            methodDictionary.Add("右に壁がないなら", new IsntRightWall());
            methodDictionary.Add("左に壁がないなら", new IsntLeftWall());
            methodDictionary.Add("いつでも", new returnTrue());
            return methodDictionary;
        }

        public class IsX2 : IsMethod
        {
            public override bool execute(GameData game)
            {
                //return game.isX2();
                return true;
            }
        }

        public class IsUpObject : IsMethod
        {
            public override bool execute(GameData game)
            {
                return  1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, 4);
            }
        }

        public class IsDownObject : IsMethod
        {
            public override bool execute(GameData game)
            {
                return 1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, 2);
            }
        }
        public class IsRightObject : IsMethod
        {
            public override bool execute(GameData game)
            {
                return 1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, 1);
            }
        }
        public class IsLeftObject : IsMethod
        {
            public override bool execute(GameData game)
            {
                return 1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, 3);
            }
        }

        /// <summary>
        /// 正面が壁なら
        /// </summary>
        public class IsUpWall : IsMethod
        {
            public override bool execute(GameData game)
            {
                return (1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, game.controlobj.objectDirection));
            }
        }
        /// <summary>
        /// 右が壁なら
        /// </summary>
        public class IsRightWall : IsMethod
        {
            public override bool execute(GameData game)
            {
                return (1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, game.controlobj.getRight()));
            }
        }
        /// <summary>
        /// 左が壁なら
        /// </summary>
        public class IsLeftWall : IsMethod
        {
            public override bool execute(GameData game)
            {
                return (1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, game.controlobj.getLeft()));
            }
        }

        /// <summary>
        /// 正面に壁がないなら
        /// </summary>
        public class IsntUpWall : IsMethod
        {
            public override bool execute(GameData game)
            {
                return !(1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, game.controlobj.objectDirection));
            }
        }
        /// <summary>
        /// 右に壁がないなら
        /// </summary>
        public class IsntRightWall : IsMethod
        {
            public override bool execute(GameData game)
            {
                return !(1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, game.controlobj.getRight()));
            }
        }
        /// <summary>
        /// 左に壁がないなら
        /// </summary>
        public class IsntLeftWall : IsMethod
        {
            public override bool execute(GameData game)
            {
                return !(1 == game.CountToObject(game.controlobj.objectPositionX, game.controlobj.objectPositionY, game.controlobj.getLeft() ));
            }
        }

        public class returnTrue : IsMethod
        {
            public override bool execute(GameData game)
            {
                return true;
            }
        }

    }


}
