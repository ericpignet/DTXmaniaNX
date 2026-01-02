using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using FDK;

namespace DTXMania
{
	internal class CActSelectPlayerSkillPanel : CActivity
	{
		// Constructor

		public CActSelectPlayerSkillPanel()
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
				this.txPlayerSkillPanel = CDTXMania.tGenerateTexture(CSkin.Path(@"Graphics\5_player skill panel.png"));

				/*
				// TODO better way to select instrument. And what about bass?
				int instrument = (CDTXMania.ConfigIni.bDrumsEnabled ? 0 : 1);

				string strPlayerName = string.IsNullOrEmpty(CDTXMania.ConfigIni.strCardName[instrument]) ? "GUEST" : CDTXMania.ConfigIni.strCardName[instrument];
				CPrivateFastFont pfPlayerName = new CPrivateFastFont(new FontFamily(CDTXMania.ConfigIni.str選曲リストフォント), 20, FontStyle.Regular);
				Bitmap bmpPlayerName = pfPlayerName.DrawPrivateFontNoEdge(strPlayerName,
																					CPrivateFont.DrawMode.Edge | CPrivateFont.DrawMode.Gradation,
																					Color.Blue, Color.Blue,
																					Color.LightGreen, Color.LightBlue);
				this.txPlayerName = CDTXMania.tGenerateTexture(bmpPlayerName, false);*/
				base.OnManagedCreateResources();
			}
		}
		public override void OnManagedReleaseResources()
		{
			if (!base.bNotActivated)
			{
				Trace.TraceInformation("ERIC OnManagedReleaseResources");
				CDTXMania.tReleaseTexture(ref this.txPlayerSkillPanel);
				CDTXMania.tReleaseTexture(ref this.txPlayerName);
				CDTXMania.tReleaseTexture(ref this.txPlayerSkillPoints);
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
				if (CDTXMania.stageSongSelection.rCurrentBox != null && this.txPlayerSkillPanel != null)
				{
					int nPlayerSkillsPanelPositionX = 900;
					int nPlayerSkillsPanelPositionY = 0;
					this.txPlayerSkillPanel.tDraw2D(CDTXMania.app.Device, nPlayerSkillsPanelPositionX, nPlayerSkillsPanelPositionY);
					if (this.txPlayerName != null)
					{
						this.txPlayerName.tDraw2D(CDTXMania.app.Device, nPlayerSkillsPanelPositionX + 4, nPlayerSkillsPanelPositionY + 6);
					}
					if (this.txPlayerSkillPoints != null)
                    {
						this.txPlayerSkillPoints.tDraw2D(CDTXMania.app.Device, nPlayerSkillsPanelPositionX + 124, nPlayerSkillsPanelPositionY + 40);
					}
				}
			}
			return 0;
		}

		public void tGeneratePlayerSkillPoints()
        {
			if (CDTXMania.stageSongSelection.rCurrentBox != null)
			{
				Trace.TraceInformation("ERIC tGeneratePlayerSkillPoints");

				// TODO better way to select instrument. And what about bass?
				int instrument = (CDTXMania.ConfigIni.bDrumsEnabled ? 0 : 1);

				// TODO REMOVE
				//CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints = 4500;

				#region [Determine font color based on player skill points]
				Color clFont = Color.White;
				Color clGradationTop = Color.White;
				Color clGradationBottom = Color.White;
				bool bGradation = false;
				if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 8500)
                {
					//Rainbow
					clGradationTop = Color.LawnGreen;
					clGradationBottom = Color.Violet;
					bGradation = true;
                }
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 8000)
                {
					//Gold
					clGradationTop = Color.Gold;
					clGradationBottom = Color.LightGoldenrodYellow;
					bGradation = true;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 7500)
                {
					//Silver
					clGradationTop = Color.Silver;
					clGradationBottom = Color.WhiteSmoke;
					bGradation = true;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 7000)
                {
					//Bronze
					clGradationTop = Color.Goldenrod;
					clGradationBottom = Color.LightGoldenrodYellow;
					bGradation = true;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 6500)
                {
					//Red -> White
					clGradationTop = Color.Red;
					clGradationBottom = Color.White;
					bGradation = true;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 6000)
                {
					//Red
					clFont = Color.Red;
                }
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 5500)
                {
					//Purple -> White
					clGradationTop = Color.DarkViolet;
					clGradationBottom = Color.White;
					bGradation = true;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 5000)
                {
					//Purple
					clFont = Color.Violet;
                }
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 4500)
				{
					//Blue -> White
					clGradationTop = Color.DodgerBlue;
					clGradationBottom = Color.White;
					bGradation = true;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 4000)
				{
					//Blue
					clFont = Color.DodgerBlue;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 3500)
				{
					//Green -> White
					clGradationTop = Color.LimeGreen;
					clGradationBottom = Color.White;
					bGradation = true;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 3000)
				{
					//Green
					clFont = Color.LimeGreen;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 2500)
				{
					//Yellow -> White
					clGradationTop = Color.Yellow;
					clGradationBottom = Color.White;
					bGradation = true;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 2000)
				{
					//Yellow
					clFont = Color.Yellow;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 1500)
				{
					//Orange -> White
					clGradationTop = Color.Orange;
					clGradationBottom = Color.White;
					bGradation = true;
				}
				else if (CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints >= 1000)
				{
					//Orange
					clFont = Color.Orange;
				}
                else
                {
					//White
					clFont = Color.White;
				}
				#endregion

				CDTXMania.tReleaseTexture(ref this.txPlayerName);
				string strPlayerName = string.IsNullOrEmpty(CDTXMania.ConfigIni.strCardName[instrument]) ? "GUEST" : CDTXMania.ConfigIni.strCardName[instrument];
				CPrivateFastFont pfPlayerName = new CPrivateFastFont(new FontFamily(CDTXMania.ConfigIni.str選曲リストフォント), 20, FontStyle.Regular);
				Bitmap bmpPlayerName;
				bmpPlayerName = pfPlayerName.DrawPrivateFont(	strPlayerName,
																CPrivateFont.DrawMode.Gradation,
																clFont,
																clFont,
																bGradation ? clGradationTop : clFont,
																bGradation ? clGradationBottom : clFont);
				this.txPlayerName = CDTXMania.tGenerateTexture(bmpPlayerName, false);
				bmpPlayerName.Dispose();
				pfPlayerName.Dispose();

				CPrivateFastFont pfPlayerSkillPoints = new CPrivateFastFont(new FontFamily(CDTXMania.ConfigIni.str選曲リストフォント), 20, FontStyle.Regular);
				Bitmap bmpPlayerSkillPoints = pfPlayerSkillPoints.DrawPrivateFont(	CDTXMania.stageSongSelection.rCurrentBox.dbBoxSkillPoints.ToString("F2"),
																					CPrivateFont.DrawMode.Gradation,
																					clFont,
																					clFont,
																					bGradation ? clGradationTop : clFont,
																					bGradation ? clGradationBottom : clFont);
				CDTXMania.tReleaseTexture(ref this.txPlayerSkillPoints);
				this.txPlayerSkillPoints = CDTXMania.tGenerateTexture(bmpPlayerSkillPoints, false);
				bmpPlayerSkillPoints.Dispose();
				pfPlayerSkillPoints.Dispose();
			}
		}

		// Other

		#region [ private ]
		//-----------------

		private CTexture txPlayerSkillPanel;
		private CTexture txPlayerSkillPoints;
		private CTexture txPlayerName;

		#endregion
	}
}
