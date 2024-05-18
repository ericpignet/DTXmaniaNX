namespace DTXMania
{
	public enum EChannel
	{
		Invalid = -1,
		Nil = 0,
		BGM = 1,
		BarLength = 2,
		BPM = 3,
		BGALayer1 = 4,
		ExObj_nouse = 5,
		MissAnimation_nouse = 6,
		BGALayer2 = 7,
		BPMEx = 8,
		BMS_reserved_09 = 9,
		BMS_reserved_0A = 10,
		HiHatClose = 17,
		Snare = 18,
		BassDrum = 19,
		HighTom = 20,
		LowTom = 21,
		Cymbal = 22,
		FloorTom = 23,
		HiHatOpen = 24,
		RideCymbal = 25,
		LeftCymbal = 26,
		LeftPedal = 27,
		LeftBassDrum = 28,
		DrumsFillin = 0x1F,
		Guitar_Open = 0x20,
		Guitar_xxBxx = 33,
		Guitar_xGxxx = 34,
		Guitar_xGBxx = 35,
		Guitar_Rxxxx = 36,
		Guitar_RxBxx = 37,
		Guitar_RGxxx = 38,
		Guitar_RGBxx = 39,
		Guitar_Wailing = 40,
		flowspeed_gt_nouse = 41,
		Guitar_LongNote = 44,
		Bass_LongNote = 45,
		Guitar_WailingSound = 47,
		flowspeed_dr_nouse = 48,
		HiHatClose_Hidden = 49,
		Snare_Hidden = 50,
		BassDrum_Hidden = 51,
		HighTom_Hidden = 52,
		LowTom_Hidden = 53,
		Cymbal_Hidden = 54,
		FloorTom_Hidden = 55,
		HiHatOpen_Hidden = 56,
		RideCymbal_Hidden = 57,
		LeftCymbal_Hidden = 58,
		LeftPedal_Hidden = 59,
		LeftBassDrum_Hidden = 60,
		BonusEffect_Min = 76,
		BonusEffect2 = 77,
		BonusEffect3 = 78,
		BonusEffect = 79,
		BarLine = 80,
		BeatLine = 81,
		MIDIChorus = 82,
		FillIn = 83,
		Movie = 84,
		BGALayer3 = 85,
		BGALayer4 = 86,
		BGALayer5 = 87,
		BGALayer6 = 88,
		BGALayer7 = 89,
		MovieFull = 90,
		nouse_5b = 91,
		nouse_5c = 92,
		nouse_5d = 93,
		nouse_5e = 94,
		nouse_5f = 95,
		BGALayer8 = 96,
		SE01 = 97,
		SE02 = 98,
		SE03 = 99,
		SE04 = 100,
		SE05 = 101,
		SE06 = 102,
		SE07 = 103,
		SE08 = 104,
		SE09 = 105,
		SE10 = 112,
		SE11 = 113,
		SE12 = 114,
		SE13 = 115,
		SE14 = 116,
		SE15 = 117,
		SE16 = 118,
		SE17 = 119,
		SE18 = 120,
		SE19 = 121,
		SE20 = 128,
		SE21 = 129,
		SE22 = 130,
		SE23 = 131,
		SE24 = 132,
		SE25 = 133,
		SE26 = 134,
		SE27 = 135,
		SE28 = 136,
		SE29 = 137,
		SE30 = 144,
		SE31 = 145,
		SE32 = 146,
		Guitar_xxxYx = 147,
		Guitar_xxBYx = 148,
		Guitar_xGxYx = 149,
		Guitar_xGBYx = 150,
		Guitar_RxxYx = 151,
		Guitar_RxBYx = 152,
		Guitar_RGxYx = 153,
		Guitar_RGBYx = 154,
		Guitar_xxxxP = 155,
		Guitar_xxBxP = 156,
		Guitar_xGxxP = 157,
		Guitar_xGBxP = 158,
		Guitar_RxxxP = 159,
		Bass_Open = 160,
		Bass_xxBxx = 161,
		Bass_xGxxx = 162,
		Bass_xGBxx = 163,
		Bass_Rxxxx = 164,
		Bass_RxBxx = 165,
		Bass_RGxxx = 166,
		Bass_RGBxx = 167,
		Bass_Wailing = 168,
		Guitar_RxBxP = 169,
		Guitar_RGxxP = 170,
		Guitar_RGBxP = 171,
		Guitar_xxxYP = 172,
		Guitar_xxBYP = 173,
		Guitar_xGxYP = 174,
		Guitar_xGBYP = 175,
		HiHatClose_NoChip = 177,
		Snare_NoChip = 178,
		BassDrum_NoChip = 179,
		HighTom_NoChip = 180,
		LowTom_NoChip = 181,
		Cymbal_NoChip = 182,
		FloorTom_NoChip = 183,
		HiHatOpen_NoChip = 184,
		RideCymbal_NoChip = 185,
		Guitar_NoChip = 186,
		Bass_NoChip = 187,
		LeftCymbal_NoChip = 188,
		LeftPedal_NoChip = 189,
		LeftBassDrum_NoChip = 190,
		BeatLineShift = 193,
		BeatLineDisplay = 194,
		BGALayer1_Swap = 196,
		Bass_xxxYx = 197,
		Bass_xxBYx = 198,
		BGALayer2_Swap = 199,
		Bass_xGxYx = 200,
		Bass_xGBYx = 201,
		Bass_RxxYx = 202,
		Bass_RxBYx = 203,
		Bass_RGxYx = 204,
		Bass_RGBYx = 205,
		Bass_xxxxP = 206,
		Bass_xxBxP = 207,
		Guitar_RxxYP = 208,
		Guitar_RxBYP = 209,
		Guitar_RGxYP = 210,
		Guitar_RGBYP = 211,
		BGALayer3_Swap = 213,
		BGALayer4_Swap = 214,
		BGALayer5_Swap = 215,
		BGALayer6_Swap = 216,
		BGALayer7_Swap = 217,
		Bass_xGxxP = 218,
		Bass_xGBxP = 219,
		Bass_RxxxP = 220,
		Bass_RxBxP = 221,
		Bass_RGxxP = 222,
		Bass_RGBxP = 223,
		BGALayer8_Swap = 224,
		Bass_xxxYP = 225,
		Bass_xxBYP = 226,
		Bass_xGxYP = 227,
		Bass_xGBYP = 228,
		Bass_RxxYP = 229,
		Bass_RxBYP = 230,
		Bass_RGxYP = 231,
		Bass_RGBYP = 232,
		MixChannel1_unc = 234,
		MixChannel2_unc = 235,
		Click = 236,
		FirstSoundChip = 237,
		MixerAdd = 238,
		MixerRemove = 239
	}
}
