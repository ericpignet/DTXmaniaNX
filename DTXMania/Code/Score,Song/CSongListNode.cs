using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;

namespace DTXMania
{
	[Serializable]
	internal class CSongListNode
	{
		// プロパティ

		public ENodeType eNodeType = ENodeType.UNKNOWN;
		public enum ENodeType
		{
			SCORE,
			SCORE_MIDI,
			BOX,
			BACKBOX,
			RANDOM,
			UNKNOWN
		}
		public int nID { get; private set; }
		public CScore[] arScore = new CScore[ 5 ];
		public string[] arDifficultyLabel = new string[ 5 ];
		public bool bDTXFilesで始まるフォルダ名のBOXである;
		public bool bBoxDefで作成されたBOXである
		{
			get
			{
				return !this.bDTXFilesで始まるフォルダ名のBOXである;
			}
			set
			{
				this.bDTXFilesで始まるフォルダ名のBOXである = !value;
			}
		}
		public Color col文字色 = Color.White;
		public List<CSongListNode> listランダム用ノードリスト;
		public List<CSongListNode> list子リスト;
		public STHitRanges stDrumHitRanges = new STHitRanges(nDefaultSizeMs: -1);
		public STHitRanges stDrumPedalHitRanges = new STHitRanges(nDefaultSizeMs: -1);
		public STHitRanges stGuitarHitRanges = new STHitRanges(nDefaultSizeMs: -1);
		public STHitRanges stBassHitRanges = new STHitRanges(nDefaultSizeMs: -1);
		public int nスコア数;
		public string pathSetDefの絶対パス = "";
		public CSongListNode r親ノード;
		public int SetDefのブロック番号;
		public Stack<int> stackRandomPerformanceNumber = new Stack<int>();
		public string strジャンル = "";
		public string strタイトル = "";
		public string strBreadcrumbs = "";		// #27060 2011.2.27 yyagi; MUSIC BOXのパンくずリスト (曲リスト構造内の絶対位置捕捉のために使う)
		public string strSkinPath = "";			// #28195 2012.5.4 yyagi; box.defでのスキン切り替え対応
        public string strバージョン = "";
        public double dbBoxSkillPoints = -1;

        // コンストラクタ

        public CSongListNode()
		{
			this.nID = id++;
		}

		//
		public CSongListNode ShallowCopyOfSelf()
        {
			CSongListNode newNode = new CSongListNode();
			newNode.eNodeType = this.eNodeType;
			newNode.nID = this.nID;
			newNode.arDifficultyLabel = this.arDifficultyLabel;
			newNode.arScore = this.arScore;
			newNode.bDTXFilesで始まるフォルダ名のBOXである = this.bDTXFilesで始まるフォルダ名のBOXである;
			newNode.bBoxDefで作成されたBOXである = this.bBoxDefで作成されたBOXである;
			newNode.col文字色 = this.col文字色;
			newNode.listランダム用ノードリスト = this.listランダム用ノードリスト;
			newNode.list子リスト = this.list子リスト;
			newNode.stDrumHitRanges = stDrumHitRanges;
			newNode.stDrumPedalHitRanges = stDrumPedalHitRanges;
			newNode.stGuitarHitRanges = stGuitarHitRanges;
			newNode.stBassHitRanges = stBassHitRanges;
			newNode.nスコア数 = this.nスコア数;
			newNode.pathSetDefの絶対パス = this.pathSetDefの絶対パス;
			newNode.r親ノード = this.r親ノード;
			newNode.SetDefのブロック番号 = this.SetDefのブロック番号;
			newNode.stackRandomPerformanceNumber = this.stackRandomPerformanceNumber;
			newNode.strジャンル = this.strジャンル;
			newNode.strタイトル = this.strタイトル;
			newNode.strバージョン = this.strバージョン;
			newNode.strBreadcrumbs = this.strBreadcrumbs;
			newNode.strSkinPath = this.strSkinPath;
            newNode.dbBoxSkillPoints = this.dbBoxSkillPoints;

            return newNode;
		}

        // Other

        public void tCalculateBoxSkillPoints(EInstrumentPart part)
        {
			if (this.eNodeType != CSongListNode.ENodeType.BOX)
                return;

            this.dbBoxSkillPoints = 0;
            List<double> listMaxes = new List<double>();
            foreach (CSongListNode node in this.list子リスト)
            {
                if (node.eNodeType != CSongListNode.ENodeType.SCORE && node.eNodeType != CSongListNode.ENodeType.SCORE_MIDI)
                    continue;

                // Find which difficulty level has the highest Song Skill...
                double nMax = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (node.arScore[i] != null && node.arScore[i].SongInformation.HighSongSkill[(int)part] > nMax)
                        nMax = node.arScore[i].SongInformation.HighSongSkill[(int)part];

                }
                // ... and add to the list
                listMaxes.Add(nMax);
            }

            //Sort the list of maxes and add up the 50 highest
            listMaxes.Sort();
            for (int i = 0; (i < listMaxes.Count) && (i < 50); i++)
            {
                this.dbBoxSkillPoints += listMaxes[listMaxes.Count - i - 1];
            }
        }

        #region [ private ]
        //-----------------
        private static int id;
		//-----------------
		#endregion
	}
}
