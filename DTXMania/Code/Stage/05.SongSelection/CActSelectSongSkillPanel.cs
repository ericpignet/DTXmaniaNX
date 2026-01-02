using System.Runtime.InteropServices;
using System.Drawing;
using FDK;
using System;

namespace DTXMania
{
	internal class CActSelectSongSkillPanel : CActivity
	{
		// Constructor

		public CActSelectSongSkillPanel()
		{
			base.bNotActivated = true;
		}

		// CActivity implementation

		public override void OnActivate()
		{
			base.OnActivate();
		}
		public override void OnDeactivate()
		{
			base.OnDeactivate();
		}
		public override void OnManagedCreateResources()
		{
			if (!base.bNotActivated)
			{
				this.txSongSkillPanel = CDTXMania.tGenerateTexture(CSkin.Path(@"Graphics\5_song skill panel.png"));
				this.txSongSkillNumbersSmall = CDTXMania.tGenerateTexture(CSkin.Path(@"Graphics\5_song skill numbers small.png"));
				this.txSongSkillNumbersLarge = CDTXMania.tGenerateTexture(CSkin.Path(@"Graphics\5_song skill numbers large.png"));
				base.OnManagedCreateResources();
			}
		}
		public override void OnManagedReleaseResources()
		{
			if (!base.bNotActivated)
			{
				CDTXMania.tReleaseTexture(ref this.txSongSkillPanel);
				CDTXMania.tReleaseTexture(ref this.txSongSkillNumbersSmall);
				CDTXMania.tReleaseTexture(ref this.txSongSkillNumbersLarge);
				base.OnManagedReleaseResources();
			}
		}
		public override int OnUpdateAndDraw()
		{
			if (!base.bNotActivated)
			{
				if (base.bJustStartedUpdate)
				{
					base.bJustStartedUpdate = false;
				}

				int nSongSkillPositionX = 450;
				int nSongSkillPositionY = 385;
				//TODO what values if status panel background doesn't exist?
				if (true) // this.txパネル本体 != null)
				{
					nSongSkillPositionX = 30;
					nSongSkillPositionY = 185;
				}

				if (this.txSongSkillPanel != null)
				{
					this.txSongSkillPanel.tDraw2D(CDTXMania.app.Device, nSongSkillPositionX, nSongSkillPositionY);
				}

				if (CDTXMania.stageSongSelection.rSelectedSong != null && this.txSongSkillNumbersSmall != null && this.txSongSkillNumbersLarge != null)
				{
					CScore cScore = CDTXMania.stageSongSelection.rSelectedScore;
					CSongListNode node = CDTXMania.stageSongSelection.rSelectedSong;
					double dbHighSongSkill = -1;
					if (CDTXMania.stageSongSelection.rSelectedSong.eNodeType == CSongListNode.ENodeType.SCORE)
					{
						// TODO SCORE_MIDI?
						// TODO Move that out of onUpdateAndDraw

						double nMax = node.tGetHighestSongSkill(CDTXMania.ConfigIni.bGuitarRevolutionMode);
						if (nMax >= 0)
							dbHighSongSkill = nMax;
					}
					/*switch (CDTXMania.stageSongSelection.rSelectedSong.eNodeType)
					{
						case CSongListNode.ENodeType.SCORE:
							{
								double dbHighSongSkill = cスコア.SongInformation.HighSongSkill.Drums;
								strHighSongSkill = dbHighSongSkill.ToString("F2");
								break;
							}
						default:
							{
								strHighSongSkill = "---";
								break;
							}
					}*/

					this.tDrawSongSkill(nSongSkillPositionX + 80, nSongSkillPositionY + 25, dbHighSongSkill/*string.Format("{0,3:###}", strHighSongSkill)*/ );
				}
			}
			return 0;
		}

		// Other

		#region [ private ]

		[StructLayout(LayoutKind.Sequential)]
		private struct STINFO
		{
			public Point pt左上座標;
			public STINFO(int x, int y)
			{
				this.pt左上座標 = new Point(x, y);
			}
		}
		private struct STSongSkillsNumber
		{
			public char ch;
			public Rectangle rc;
			public STSongSkillsNumber(char ch, Rectangle rc)
			{
				this.ch = ch;
				this.rc = rc;
			}
		}

		private readonly STSongSkillsNumber[] stSongSkillNumberSmall = new STSongSkillsNumber[]
		{
			//TODO remove unwanted characters from image and code
            new STSongSkillsNumber('0', new Rectangle(0 * 12, 0, 12, 20)),
			new STSongSkillsNumber('1', new Rectangle(1 * 12, 0, 12, 20)),
			new STSongSkillsNumber('2', new Rectangle(2 * 12, 0, 12, 20)),
			new STSongSkillsNumber('3', new Rectangle(3 * 12, 0, 12, 20)),
			new STSongSkillsNumber('4', new Rectangle(4 * 12, 0, 12, 20)),
			new STSongSkillsNumber('5', new Rectangle(5 * 12, 0, 12, 20)),
			new STSongSkillsNumber('6', new Rectangle(6 * 12, 0, 12, 20)),
			new STSongSkillsNumber('7', new Rectangle(7 * 12, 0, 12, 20)),
			new STSongSkillsNumber('8', new Rectangle(8 * 12, 0, 12, 20)),
			new STSongSkillsNumber('9', new Rectangle(9 * 12, 0, 12, 20)),
			new STSongSkillsNumber('.', new Rectangle(10 * 12, 0, 6, 20)),
			new STSongSkillsNumber('%', new Rectangle(11 * 12 - 6, 0, 12, 20))
		};
		private readonly STSongSkillsNumber[] stSongSkillNumberLarge = new STSongSkillsNumber[]
		{
			//TODO remove unwanted characters from image and code
			new STSongSkillsNumber('0', new Rectangle(0 * 20, 0, 20, 28)),
			new STSongSkillsNumber('1', new Rectangle(1 * 20, 0, 20, 28)),
			new STSongSkillsNumber('2', new Rectangle(2 * 20, 0, 20, 28)),
			new STSongSkillsNumber('3', new Rectangle(3 * 20, 0, 20, 28)),
			new STSongSkillsNumber('4', new Rectangle(4 * 20, 0, 20, 28)),
			new STSongSkillsNumber('5', new Rectangle(5 * 20, 0, 20, 28)),
			new STSongSkillsNumber('6', new Rectangle(6 * 20, 0, 20, 28)),
			new STSongSkillsNumber('7', new Rectangle(7 * 20, 0, 20, 28)),
			new STSongSkillsNumber('8', new Rectangle(8 * 20, 0, 20, 28)),
			new STSongSkillsNumber('9', new Rectangle(9 * 20, 0, 20, 28)),
			new STSongSkillsNumber('.', new Rectangle(10 * 20, 0, 10, 28)),
			new STSongSkillsNumber('-', new Rectangle(11 * 20 - 10, 0, 20, 28)),
			new STSongSkillsNumber('?', new Rectangle(12 * 20 - 10, 0, 20, 28))
		};
		private CTexture txSongSkillPanel;
		private CTexture txSongSkillNumbersSmall;
		private CTexture txSongSkillNumbersLarge;

		private void tDrawSongSkill(int x, int y, double dbHighSongSkill)
		{
			if (dbHighSongSkill == -1)
			{
				return;
			}
			int nIntegerPart = (int)Math.Truncate(dbHighSongSkill);
			int nDecimalPart = (int) ((dbHighSongSkill - Math.Truncate(dbHighSongSkill))*100);

			// Draw integer part
			string strIntegerPart = nIntegerPart.ToString() + ".";
			for (int iIntegerPart = 0; iIntegerPart < strIntegerPart.Length; iIntegerPart++)
			{
				char c = strIntegerPart[iIntegerPart];
				for (int i = 0; i < this.stSongSkillNumberLarge.Length; i++)
				{
					if (this.stSongSkillNumberLarge[i].ch == c)
					{
						Rectangle rectangle = new Rectangle(this.stSongSkillNumberLarge[i].rc.X, this.stSongSkillNumberLarge[i].rc.Y, 20, 28);
						if (c == '.')
						{
							rectangle.Width -= 10;
						}
						if (this.txSongSkillNumbersLarge != null)
						{
							this.txSongSkillNumbersLarge.tDraw2D(CDTXMania.app.Device, x, y, rectangle);
						}
						break;
					}
				}
				if (c == '.')
				{
					x += 10;
				}
				else
				{
					x += 20;
				}
			}

			// Draw decimal part
			y += 7;
			string strDecimalPart = nDecimalPart.ToString("D2");
			for (int iDecimalPart = 0; iDecimalPart < strDecimalPart.Length; iDecimalPart++)
			{
				char c = strDecimalPart[iDecimalPart];
				for (int i = 0; i < this.stSongSkillNumberSmall.Length; i++)
				{
					if (this.stSongSkillNumberSmall[i].ch == c)
					{
						Rectangle rectangle = new Rectangle(this.stSongSkillNumberSmall[i].rc.X, this.stSongSkillNumberSmall[i].rc.Y, 12, 20);
						if (this.txSongSkillNumbersSmall != null)
						{
							this.txSongSkillNumbersSmall.tDraw2D(CDTXMania.app.Device, x, y, rectangle);
						}
						break;
					}
				}
				x += 16;
			}
		}



		#endregion
	}
}
