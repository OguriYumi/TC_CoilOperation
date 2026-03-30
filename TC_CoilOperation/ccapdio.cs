using System;
using System.Text;
using System.Runtime.InteropServices;

namespace DIO
{
	/// <summary>
	/// ccapdio の概要の説明です。
	/// </summary>
	public class ccapdio
	{
		public ccapdio()
		{
			// 
			// TODO: コンストラクタ ロジックをここに追加してください。
			//
		}
		//======================================================================
		//======================================================================
		//	API-CAP(W32)
		//	CCAPDIO.CS					CONTEC.CO.,LTD.
		//======================================================================
		//======================================================================


		//======================================================================
		// Error Code
		//======================================================================
		public const short DIO_ERR_SUCCESS = 0;     //正常終了 
		public const short DIO_ERR_INI_MEMORY = 3;      //メモリの割り当てに失敗しました。 
		public const short DIO_ERR_INI_REGISTRY = 4;        //設定ファイルのアクセスに失敗しました。 
		public const short DIO_ERR_DLL_DEVICE_NAME = 10000; //設定ファイルに登録されていないデバイス名が指定されました。 
		public const short DIO_ERR_DLL_INVALID_ID = 10001;  //無効なIDが指定されました。 
		public const short DIO_ERR_DLL_CREATE_FILE = 10003; //ハンドルの取得に作成に失敗しました。 
		public const short DIO_ERR_DLL_CLOSE_FILE = 10004;  //ハンドルのクローズに失敗しました。 
		public const short DIO_ERR_ACCESS_RIGHT = 10005;    //アクセス権エラーです。
		public const short DIO_ERR_DLL_TIMEOUT = 10006; //通信タイムアウトが発生しました。
		public const short DIO_ERR_COMPOSITION = 10007; //機器構成エラーです。
		public const short DIO_ERR_INFO_INVALID_DEVICE = 10050; //指定したデバイス名称が見つかりません。スペルを確認してください。 
		public const short DIO_ERR_INFO_NOT_FIND_DEVICE = 10051;    //利用可能なデバイスが見つかりません。 
		public const short DIO_ERR_DLL_BUFF_ADDRESS = 10100;    //データバッファアドレスが不正です。 
		public const short DIO_ERR_SYS_NOT_SUPPORTED = 20001;   //このデバイスではこの関数は使用できません。
		public const short DIO_ERR_SYS_PORT_NO = 20100; //ポート番号が指定可能範囲を超えています。 
		public const short DIO_ERR_SYS_PORT_NUM = 20101;    //ポート数が指定可能範囲を超えています。 
		public const short DIO_ERR_SYS_BIT_NO = 20102;  //ビット番号が指定可能範囲を超えています。 
		public const short DIO_ERR_SYS_BIT_NUM = 20103; //ビット数が指定可能範囲を超えています。 
		public const short DIO_ERR_SYS_BIT_DATA = 20104;    //ビットデータが0か1以外です。 
		public const short DIO_ERR_SYS_DIRECTION = 20106;   //入出力方向が指定範囲外です。
		public const short DIO_ERR_SYS_FILTER = 20400;  //フィルタ時定数が指定範囲外です。 

		//======================================================================
		// Function Prototype
		//======================================================================
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioInit(string Devicename, ref short Id);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioExit(short Id);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioGetErrorString(int Err, StringBuilder szMsg);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioQueryDeviceName(short Index, ref short GroupID, ref short UnitID, ref short DeviceID, StringBuilder DeviceName, StringBuilder Device);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioSetDirectMode(short Id, short DirectMode);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioSetIOInterval(int Interval);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioGetRemoteStatus(short Id, ref byte Start, ref byte Status);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioSetDigitalFilter(short Id, short FilterValue);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioGetDigitalFilter(short Id, ref short FilterValue);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioSetIoDirection(short Id, int Dir);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioGetIoDirection(short Id, ref int Dir);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioInpByte(short Id, short PortNo, ref byte Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioInpBit(short Id, short BitNo, ref byte Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioOutByte(short Id, short PortNo, byte Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioOutBit(short Id, short BitNo, byte Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioEchoBackByte(short Id, short PortNo, ref byte Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioEchoBackBit(short Id, short BitNo, ref byte Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioInpMultiByte(short Id, [MarshalAs(UnmanagedType.LPArray)] short[] PortNo, short PortNum, [MarshalAs(UnmanagedType.LPArray)] byte[] Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioInpMultiBit(short Id, [MarshalAs(UnmanagedType.LPArray)] short[] BitNo, short BitNum, [MarshalAs(UnmanagedType.LPArray)] byte[] Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioOutMultiByte(short Id, [MarshalAs(UnmanagedType.LPArray)] short[] PortNo, short PortNum, [MarshalAs(UnmanagedType.LPArray)] byte[] Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioOutMultiBit(short Id, [MarshalAs(UnmanagedType.LPArray)] short[] BitNo, short BitNum, [MarshalAs(UnmanagedType.LPArray)] byte[] Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioEchoBackMultiByte(short Id, [MarshalAs(UnmanagedType.LPArray)] short[] PortNo, short PortNum, [MarshalAs(UnmanagedType.LPArray)] byte[] Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioEchoBackMultiBit(short Id, [MarshalAs(UnmanagedType.LPArray)] short[] BitNo, short BitNum, [MarshalAs(UnmanagedType.LPArray)] byte[] Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioGetMaxPorts(short Id, ref short InPortNum, ref short OutPortNum);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioGetMaxBits(short Id, ref short InBitNum, ref short OutBitNum);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioResetPatternEvent(short Id, [MarshalAs(UnmanagedType.LPArray)] byte[] Data);
		[DllImport("CCAPDIO.DLL")]
		public static extern int DioGetPatternEventStatus(short Id, ref short Status, short EventType);

	}
}