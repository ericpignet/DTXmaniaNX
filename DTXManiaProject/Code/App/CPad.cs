﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using FDK;

namespace DTXMania
{
    public class CPad
	{
		// プロパティ

		internal STHIT st検知したデバイス;
		[StructLayout( LayoutKind.Sequential )]
		internal struct STHIT
		{
			public bool Keyboard;
			public bool MIDIIN;
			public bool Joypad;
			public bool Mouse;
			public void Clear()
			{
				this.Keyboard = false;
				this.MIDIIN = false;
				this.Joypad = false;
				this.Mouse = false;
			}
		}


		// コンストラクタ

		internal CPad( CConfigIni configIni, CInputManager mgrInput )
		{
			this.rConfigIni = configIni;
			this.rInput管理 = mgrInput;
			this.st検知したデバイス.Clear();
		}


		// メソッド

		public List<STInputEvent> GetEvents( EInstrumentPart part, EPad pad )
		{
			CConfigIni.CKeyAssign.STKEYASSIGN[] stkeyassignArray = this.rConfigIni.KeyAssign[ (int) part ][ (int) pad ];
			List<STInputEvent> list = new List<STInputEvent>();

			// すべての入力デバイスについて…
			foreach( IInputDevice device in this.rInput管理.listInputDevices )
			{
				if( ( device.list入力イベント != null ) && ( device.list入力イベント.Count != 0 ) )
				{
					foreach( STInputEvent event2 in device.list入力イベント )
					{
						for( int i = 0; i < stkeyassignArray.Length; i++ )
						{
							switch( stkeyassignArray[ i ].InputDevice )
							{
								case EInputDevice.Keyboard:
									if( ( device.eInputDeviceType == EInputDeviceType.Keyboard ) && ( event2.nKey == stkeyassignArray[ i ].Code ) )
									{
										list.Add( event2 );
										this.st検知したデバイス.Keyboard = true;
									}
									break;

								case EInputDevice.MIDI入力:
									if( ( ( device.eInputDeviceType == EInputDeviceType.MidiIn ) && ( device.ID == stkeyassignArray[ i ].ID ) ) && ( event2.nKey == stkeyassignArray[ i ].Code ) )
									{
										list.Add( event2 );
										this.st検知したデバイス.MIDIIN = true;
									}
									break;

								case EInputDevice.Joypad:
									if( ( ( device.eInputDeviceType == EInputDeviceType.Joystick ) && ( device.ID == stkeyassignArray[ i ].ID ) ) && ( event2.nKey == stkeyassignArray[ i ].Code ) )
									{
										list.Add( event2 );
										this.st検知したデバイス.Joypad = true;
									}
									break;

								case EInputDevice.Mouse:
									if( ( device.eInputDeviceType == EInputDeviceType.Mouse ) && ( event2.nKey == stkeyassignArray[ i ].Code ) )
									{
										list.Add( event2 );
										this.st検知したデバイス.Mouse = true;
									}
									break;
							}
						}
					}
					continue;
				}
			}
			return list;
		}
		public bool bPressed( EInstrumentPart part, EPad pad )
		{
			if( part != EInstrumentPart.UNKNOWN )
			{
				
				CConfigIni.CKeyAssign.STKEYASSIGN[] stkeyassignArray = this.rConfigIni.KeyAssign[ (int) part ][ (int) pad ];
				for( int i = 0; i < stkeyassignArray.Length; i++ )
				{
					switch( stkeyassignArray[ i ].InputDevice )
					{
						case EInputDevice.Keyboard:
							if( !this.rInput管理.Keyboard.bキーが押された( stkeyassignArray[ i ].Code ) )
								break;

							this.st検知したデバイス.Keyboard = true;
							return true;

						case EInputDevice.MIDI入力:
							{
								IInputDevice device2 = this.rInput管理.MidiIn( stkeyassignArray[ i ].ID );
								if( ( device2 == null ) || !device2.bキーが押された( stkeyassignArray[ i ].Code ) )
									break;

								this.st検知したデバイス.MIDIIN = true;
								return true;
							}
						case EInputDevice.Joypad:
							{
								if( !this.rConfigIni.dicJoystick.ContainsKey( stkeyassignArray[ i ].ID ) )
									break;

								IInputDevice device = this.rInput管理.Joystick( stkeyassignArray[ i ].ID );
								if( ( device == null ) || !device.bキーが押された( stkeyassignArray[ i ].Code ) )
									break;

								this.st検知したデバイス.Joypad = true;
								return true;
							}
						case EInputDevice.Mouse:
							if( !this.rInput管理.Mouse.bキーが押された( stkeyassignArray[ i ].Code ) )
								break;

							this.st検知したデバイス.Mouse = true;
							return true;
					}
				}
			}
			return false;
		}
		public bool bPressedDGB( EPad pad )
		{
			if( !this.bPressed( EInstrumentPart.DRUMS, pad ) && !this.bPressed( EInstrumentPart.GUITAR, pad ) )
			{
				return this.bPressed( EInstrumentPart.BASS, pad );
			}
			return true;
		}
		public bool bPressedGB( EPad pad )
		{
			if( !this.bPressed( EInstrumentPart.GUITAR, pad ) )
			{
				return this.bPressed( EInstrumentPart.BASS, pad );
			}
			return true;
		}
		public bool bPressing( EInstrumentPart part, EPad pad )
		{
			if( part != EInstrumentPart.UNKNOWN )
			{
				CConfigIni.CKeyAssign.STKEYASSIGN[] stkeyassignArray = this.rConfigIni.KeyAssign[ (int) part ][ (int) pad ];
				for( int i = 0; i < stkeyassignArray.Length; i++ )
				{
					switch( stkeyassignArray[ i ].InputDevice )
					{
						case EInputDevice.Keyboard:
							if( !this.rInput管理.Keyboard.bキーが押されている( stkeyassignArray[ i ].Code ) )
							{
								break;
							}
							this.st検知したデバイス.Keyboard = true;
							return true;

						case EInputDevice.Joypad:
							{
								if( !this.rConfigIni.dicJoystick.ContainsKey( stkeyassignArray[ i ].ID ) )
								{
									break;
								}
								IInputDevice device = this.rInput管理.Joystick( stkeyassignArray[ i ].ID );
								if( ( device == null ) || !device.bキーが押されている( stkeyassignArray[ i ].Code ) )
								{
									break;
								}
								this.st検知したデバイス.Joypad = true;
								return true;
							}
						case EInputDevice.Mouse:
							if( !this.rInput管理.Mouse.bキーが押されている( stkeyassignArray[ i ].Code ) )
							{
								break;
							}
							this.st検知したデバイス.Mouse = true;
							return true;
					}
				}
			}
			return false;
		}
		public bool b押されているGB( EPad pad )
		{
			if( !this.bPressing( EInstrumentPart.GUITAR, pad ) )
			{
				return this.bPressing( EInstrumentPart.BASS, pad );
			}
			return true;
		}


		// Other

		#region [ private ]
		//-----------------
		private CConfigIni rConfigIni;
		private CInputManager rInput管理;
		//-----------------
		#endregion
	}
}
