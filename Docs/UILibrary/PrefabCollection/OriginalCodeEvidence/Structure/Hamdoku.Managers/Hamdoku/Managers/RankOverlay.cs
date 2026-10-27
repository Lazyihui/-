namespace Hamdoku.Managers;

[Token(Token = "0x20001F2")]
public sealed class RankOverlay : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[CompilerGenerated]
	[Token(Token = "0x20001F8")]
	private sealed class <>c
	{
		[Token(Token = "0x4000CC6")]
		public static readonly <>c <>9; //Field offset: 0x0
		[Token(Token = "0x4000CC7")]
		public static Predicate<RankEntry> <>9__49_0; //Field offset: 0x8
		[Token(Token = "0x4000CC8")]
		public static TweenCallback <>9__74_3; //Field offset: 0x10

		[Address(RVA = "0x327179C", Offset = "0x327179C", Length = "0x68")]
		[Token(Token = "0x6000E96")]
		private static <>c() { }

		[Address(RVA = "0x3271804", Offset = "0x3271804", Length = "0x8")]
		[Token(Token = "0x6000E97")]
		public <>c() { }

		[Address(RVA = "0x327180C", Offset = "0x327180C", Length = "0x1C")]
		[Token(Token = "0x6000E98")]
		internal bool <BuildRows>b__49_0(RankEntry e) { }

		[Address(RVA = "0x3271828", Offset = "0x3271828", Length = "0x84")]
		[Token(Token = "0x6000E99")]
		internal void <Sequence>b__74_3() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001F9")]
	private struct <>c__DisplayClass69_0
	{
		[FieldOffset(Offset = "0x0")]
		[Token(Token = "0x4000CC9")]
		public float w; //Field offset: 0x0
		[FieldOffset(Offset = "0x4")]
		[Token(Token = "0x4000CCA")]
		public float h; //Field offset: 0x4

	}

	[CompilerGenerated]
	[Token(Token = "0x20001FA")]
	private sealed class <>c__DisplayClass74_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CCB")]
		public RankOverlay <>4__this; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000CCC")]
		public int total; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000CCD")]
		public Action<bool> <>9__0; //Field offset: 0x20

		[Address(RVA = "0x32718AC", Offset = "0x32718AC", Length = "0x8")]
		[Token(Token = "0x6000E9A")]
		public <>c__DisplayClass74_0() { }

		[Address(RVA = "0x32718B4", Offset = "0x32718B4", Length = "0x394")]
		[Token(Token = "0x6000E9B")]
		internal void <Sequence>b__0(bool last) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001FB")]
	private sealed class <>c__DisplayClass74_1
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CCE")]
		public int from; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000CCF")]
		public TMP_Text label; //Field offset: 0x18

		[Address(RVA = "0x3271C48", Offset = "0x3271C48", Length = "0x8")]
		[Token(Token = "0x6000E9C")]
		public <>c__DisplayClass74_1() { }

		[Address(RVA = "0x3271C50", Offset = "0x3271C50", Length = "0xC")]
		[Token(Token = "0x6000E9D")]
		internal float <Sequence>b__1() { }

		[Address(RVA = "0x3271C5C", Offset = "0x3271C5C", Length = "0x15C")]
		[Token(Token = "0x6000E9E")]
		internal void <Sequence>b__2(float v) { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001FC")]
	private sealed class <>c__DisplayClass90_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CD0")]
		public GameObject go; //Field offset: 0x10

		[Address(RVA = "0x3271DB8", Offset = "0x3271DB8", Length = "0x8")]
		[Token(Token = "0x6000E9F")]
		public <>c__DisplayClass90_0() { }

		[Address(RVA = "0x3271DC0", Offset = "0x3271DC0", Length = "0x5C")]
		[Token(Token = "0x6000EA0")]
		internal void <ArrowBurst>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001FD")]
	private sealed class <>c__DisplayClass91_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CD1")]
		public GameObject go; //Field offset: 0x10

		[Address(RVA = "0x3271E1C", Offset = "0x3271E1C", Length = "0x8")]
		[Token(Token = "0x6000EA1")]
		public <>c__DisplayClass91_0() { }

		[Address(RVA = "0x3271E24", Offset = "0x3271E24", Length = "0x5C")]
		[Token(Token = "0x6000EA2")]
		internal void <SparklePopAtPill>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001FE")]
	private sealed class <>c__DisplayClass92_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CD2")]
		public GameObject go; //Field offset: 0x10

		[Address(RVA = "0x3271E80", Offset = "0x3271E80", Length = "0x8")]
		[Token(Token = "0x6000EA3")]
		public <>c__DisplayClass92_0() { }

		[Address(RVA = "0x3271E88", Offset = "0x3271E88", Length = "0x90")]
		[Token(Token = "0x6000EA4")]
		internal void <RowEdgeGlow>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x20001FF")]
	private sealed class <>c__DisplayClass93_0
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CD3")]
		public GameObject go; //Field offset: 0x10

		[Address(RVA = "0x3271F18", Offset = "0x3271F18", Length = "0x8")]
		[Token(Token = "0x6000EA5")]
		public <>c__DisplayClass93_0() { }

		[Address(RVA = "0x3271F20", Offset = "0x3271F20", Length = "0x5C")]
		[Token(Token = "0x6000EA6")]
		internal void <SparkleBurst>b__0() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000200")]
	private sealed class <ChromeRoots>d__103 : IEnumerable<GameObject>, IEnumerable, IEnumerator<GameObject>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CD4")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000CD5")]
		private GameObject <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000CD6")]
		private int <>l__initialThreadId; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000CD7")]
		private GameHUD[] <>7__wrap1; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000CD8")]
		private int <>7__wrap2; //Field offset: 0x30
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000CD9")]
		private RuleBannerView[] <>7__wrap3; //Field offset: 0x38

		[Token(Token = "0x17000202")]
		private GameObject System.Collections.Generic.IEnumerator<UnityEngine.GameObject>.Current
		{
			[Address(RVA = "0x32721FC", Offset = "0x32721FC", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EAA")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000203")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x327223C", Offset = "0x327223C", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EAC")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x3271F7C", Offset = "0x3271F7C", Length = "0x34")]
		[DebuggerHidden]
		[Token(Token = "0x6000EA7")]
		public <ChromeRoots>d__103(int <>1__state) { }

		[Address(RVA = "0x3271FB4", Offset = "0x3271FB4", Length = "0x248")]
		[Token(Token = "0x6000EA9")]
		private bool MoveNext() { }

		[Address(RVA = "0x3272244", Offset = "0x3272244", Length = "0x90")]
		[DebuggerHidden]
		[Token(Token = "0x6000EAD")]
		private IEnumerator<GameObject> System.Collections.Generic.IEnumerable<UnityEngine.GameObject>.GetEnumerator() { }

		[Address(RVA = "0x32721FC", Offset = "0x32721FC", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EAA")]
		private GameObject System.Collections.Generic.IEnumerator<UnityEngine.GameObject>.get_Current() { }

		[Address(RVA = "0x32722D4", Offset = "0x32722D4", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000EAE")]
		private IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

		[Address(RVA = "0x327223C", Offset = "0x327223C", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EAC")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x3272204", Offset = "0x3272204", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000EAB")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x3271FB0", Offset = "0x3271FB0", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000EA8")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000201")]
	private sealed class <CloseCo>d__105 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CDA")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000CDB")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000CDC")]
		public RankOverlay <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000CDD")]
		private float <e>5__2; //Field offset: 0x28
		[FieldOffset(Offset = "0x2C")]
		[Token(Token = "0x4000CDE")]
		private float <from>5__3; //Field offset: 0x2C

		[Token(Token = "0x17000204")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x32724BC", Offset = "0x32724BC", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EB2")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000205")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x32724FC", Offset = "0x32724FC", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EB4")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x32722D8", Offset = "0x32722D8", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000EAF")]
		public <CloseCo>d__105(int <>1__state) { }

		[Address(RVA = "0x3272304", Offset = "0x3272304", Length = "0x1B8")]
		[Token(Token = "0x6000EB1")]
		private bool MoveNext() { }

		[Address(RVA = "0x32724BC", Offset = "0x32724BC", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EB2")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x32724FC", Offset = "0x32724FC", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EB4")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x32724C4", Offset = "0x32724C4", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000EB3")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x3272300", Offset = "0x3272300", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000EB0")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000202")]
	private sealed class <RollValue>d__83 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CDF")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000CE0")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000CE1")]
		public float dur; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000CE2")]
		public RankOverlay <>4__this; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000CE3")]
		public int from; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x4000CE4")]
		public int to; //Field offset: 0x34
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000CE5")]
		private float <e>5__2; //Field offset: 0x38

		[Token(Token = "0x17000206")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x32727D4", Offset = "0x32727D4", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EB8")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000207")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x3272814", Offset = "0x3272814", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EBA")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x3272504", Offset = "0x3272504", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000EB5")]
		public <RollValue>d__83(int <>1__state) { }

		[Address(RVA = "0x3272530", Offset = "0x3272530", Length = "0x2A4")]
		[Token(Token = "0x6000EB7")]
		private bool MoveNext() { }

		[Address(RVA = "0x32727D4", Offset = "0x32727D4", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EB8")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x3272814", Offset = "0x3272814", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EBA")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x32727DC", Offset = "0x32727DC", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000EB9")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x327252C", Offset = "0x327252C", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000EB6")]
		private void System.IDisposable.Dispose() { }

	}

	[CompilerGenerated]
	[Token(Token = "0x2000203")]
	private sealed class <Sequence>d__74 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[FieldOffset(Offset = "0x10")]
		[Token(Token = "0x4000CE6")]
		private int <>1__state; //Field offset: 0x10
		[FieldOffset(Offset = "0x18")]
		[Token(Token = "0x4000CE7")]
		private object <>2__current; //Field offset: 0x18
		[FieldOffset(Offset = "0x20")]
		[Token(Token = "0x4000CE8")]
		public RankOverlay <>4__this; //Field offset: 0x20
		[FieldOffset(Offset = "0x28")]
		[Token(Token = "0x4000CE9")]
		private <>c__DisplayClass74_0 <>8__1; //Field offset: 0x28
		[FieldOffset(Offset = "0x30")]
		[Token(Token = "0x4000CEA")]
		private float <e>5__2; //Field offset: 0x30
		[FieldOffset(Offset = "0x34")]
		[Token(Token = "0x4000CEB")]
		private float <w>5__3; //Field offset: 0x34
		[FieldOffset(Offset = "0x38")]
		[Token(Token = "0x4000CEC")]
		private float <g2>5__4; //Field offset: 0x38
		[FieldOffset(Offset = "0x40")]
		[Token(Token = "0x4000CED")]
		private GameObject <srcGo>5__5; //Field offset: 0x40
		[FieldOffset(Offset = "0x48")]
		[Token(Token = "0x4000CEE")]
		private RectTransform <src>5__6; //Field offset: 0x48
		[FieldOffset(Offset = "0x50")]
		[Token(Token = "0x4000CEF")]
		private float <interval>5__7; //Field offset: 0x50
		[FieldOffset(Offset = "0x54")]
		[Token(Token = "0x4000CF0")]
		private float <guard>5__8; //Field offset: 0x54
		[FieldOffset(Offset = "0x58")]
		[Token(Token = "0x4000CF1")]
		private int <i>5__9; //Field offset: 0x58
		[FieldOffset(Offset = "0x5C")]
		[Token(Token = "0x4000CF2")]
		private float <iv>5__10; //Field offset: 0x5C

		[Token(Token = "0x17000208")]
		private object System.Collections.Generic.IEnumerator<System.Object>.Current
		{
			[Address(RVA = "0x3273F70", Offset = "0x3273F70", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EBE")]
			 get { } //Length: 8
		}

		[Token(Token = "0x17000209")]
		private object System.Collections.IEnumerator.Current
		{
			[Address(RVA = "0x3273FB0", Offset = "0x3273FB0", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000EC0")]
			 get { } //Length: 8
		}

		[Address(RVA = "0x327281C", Offset = "0x327281C", Length = "0x28")]
		[DebuggerHidden]
		[Token(Token = "0x6000EBB")]
		public <Sequence>d__74(int <>1__state) { }

		[Address(RVA = "0x3272848", Offset = "0x3272848", Length = "0x1290")]
		[Token(Token = "0x6000EBD")]
		private bool MoveNext() { }

		[Address(RVA = "0x3273F70", Offset = "0x3273F70", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EBE")]
		private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

		[Address(RVA = "0x3273FB0", Offset = "0x3273FB0", Length = "0x8")]
		[DebuggerHidden]
		[Token(Token = "0x6000EC0")]
		private object System.Collections.IEnumerator.get_Current() { }

		[Address(RVA = "0x3273F78", Offset = "0x3273F78", Length = "0x38")]
		[DebuggerHidden]
		[Token(Token = "0x6000EBF")]
		private void System.Collections.IEnumerator.Reset() { }

		[Address(RVA = "0x3272844", Offset = "0x3272844", Length = "0x4")]
		[DebuggerHidden]
		[Token(Token = "0x6000EBC")]
		private void System.IDisposable.Dispose() { }

	}

	[Token(Token = "0x20001F6")]
	private sealed class DemoRunner : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x20001F7")]
		private sealed class <Run>d__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[FieldOffset(Offset = "0x10")]
			[Token(Token = "0x4000CC0")]
			private int <>1__state; //Field offset: 0x10
			[FieldOffset(Offset = "0x18")]
			[Token(Token = "0x4000CC1")]
			private object <>2__current; //Field offset: 0x18
			[FieldOffset(Offset = "0x20")]
			[Token(Token = "0x4000CC2")]
			public int gain; //Field offset: 0x20
			[FieldOffset(Offset = "0x28")]
			[Token(Token = "0x4000CC3")]
			public DemoRunner <>4__this; //Field offset: 0x28
			[FieldOffset(Offset = "0x30")]
			[Token(Token = "0x4000CC4")]
			private Task<WeeklyView> <task>5__2; //Field offset: 0x30
			[FieldOffset(Offset = "0x38")]
			[Token(Token = "0x4000CC5")]
			private float <w>5__3; //Field offset: 0x38

			[Token(Token = "0x17000200")]
			private object System.Collections.Generic.IEnumerator<System.Object>.Current
			{
				[Address(RVA = "0x3271754", Offset = "0x3271754", Length = "0x8")]
				[DebuggerHidden]
				[Token(Token = "0x6000E93")]
				 get { } //Length: 8
			}

			[Token(Token = "0x17000201")]
			private object System.Collections.IEnumerator.Current
			{
				[Address(RVA = "0x3271794", Offset = "0x3271794", Length = "0x8")]
				[DebuggerHidden]
				[Token(Token = "0x6000E95")]
				 get { } //Length: 8
			}

			[Address(RVA = "0x32713A8", Offset = "0x32713A8", Length = "0x28")]
			[DebuggerHidden]
			[Token(Token = "0x6000E90")]
			public <Run>d__0(int <>1__state) { }

			[Address(RVA = "0x32713DC", Offset = "0x32713DC", Length = "0x378")]
			[Token(Token = "0x6000E92")]
			private bool MoveNext() { }

			[Address(RVA = "0x3271754", Offset = "0x3271754", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000E93")]
			private object System.Collections.Generic.IEnumerator<System.Object>.get_Current() { }

			[Address(RVA = "0x3271794", Offset = "0x3271794", Length = "0x8")]
			[DebuggerHidden]
			[Token(Token = "0x6000E95")]
			private object System.Collections.IEnumerator.get_Current() { }

			[Address(RVA = "0x327175C", Offset = "0x327175C", Length = "0x38")]
			[DebuggerHidden]
			[Token(Token = "0x6000E94")]
			private void System.Collections.IEnumerator.Reset() { }

			[Address(RVA = "0x32713D8", Offset = "0x32713D8", Length = "0x4")]
			[DebuggerHidden]
			[Token(Token = "0x6000E91")]
			private void System.IDisposable.Dispose() { }

		}


		[Address(RVA = "0x32713D0", Offset = "0x32713D0", Length = "0x8")]
		[Token(Token = "0x6000E8F")]
		public DemoRunner() { }

		[Address(RVA = "0x327132C", Offset = "0x327132C", Length = "0x7C")]
		[IteratorStateMachine(typeof(<Run>d__0))]
		[Token(Token = "0x6000E8E")]
		public IEnumerator Run(int gain) { }

	}

	[Token(Token = "0x20001F3")]
	private static class GameChrome
	{
		[CompilerGenerated]
		[Token(Token = "0x20001F5")]
		private sealed class <>c__DisplayClass6_0
		{
			[FieldOffset(Offset = "0x10")]
			[Token(Token = "0x4000CBF")]
			public int gen; //Field offset: 0x10

			[Address(RVA = "0x3270F60", Offset = "0x3270F60", Length = "0x8")]
			[Token(Token = "0x6000E8C")]
			public <>c__DisplayClass6_0() { }

			[Address(RVA = "0x32712D4", Offset = "0x32712D4", Length = "0x58")]
			[Token(Token = "0x6000E8D")]
			internal void <Release>b__0() { }

		}

		[Token(Token = "0x20001F4")]
		private sealed class Entry
		{
			[FieldOffset(Offset = "0x10")]
			[Token(Token = "0x4000CBB")]
			public CanvasGroup cg; //Field offset: 0x10
			[FieldOffset(Offset = "0x18")]
			[Token(Token = "0x4000CBC")]
			public float alpha; //Field offset: 0x18
			[FieldOffset(Offset = "0x1C")]
			[Token(Token = "0x4000CBD")]
			public bool added; //Field offset: 0x1C
			[FieldOffset(Offset = "0x20")]
			[Token(Token = "0x4000CBE")]
			public Tween tw; //Field offset: 0x20

			[Address(RVA = "0x3270B70", Offset = "0x3270B70", Length = "0x8")]
			[Token(Token = "0x6000E8B")]
			public Entry() { }

		}

		[Token(Token = "0x4000CB8")]
		private static readonly List<Entry> _entries; //Field offset: 0x0
		[Token(Token = "0x4000CB9")]
		private static int _refs; //Field offset: 0x8
		[Token(Token = "0x4000CBA")]
		private static int _gen; //Field offset: 0xC

		[Address(RVA = "0x327123C", Offset = "0x327123C", Length = "0x98")]
		[Token(Token = "0x6000E8A")]
		private static GameChrome() { }

		[Address(RVA = "0x32703CC", Offset = "0x32703CC", Length = "0x7A4")]
		[Token(Token = "0x6000E87")]
		public static void Acquire(IEnumerable<GameObject> roots) { }

		[Address(RVA = "0x3270F68", Offset = "0x3270F68", Length = "0x2D4")]
		[Token(Token = "0x6000E89")]
		private static void Finish(int gen) { }

		[Address(RVA = "0x3270B78", Offset = "0x3270B78", Length = "0x3E8")]
		[Token(Token = "0x6000E88")]
		public static void Release(bool fade) { }

		[Address(RVA = "0x3270330", Offset = "0x3270330", Length = "0x9C")]
		[Token(Token = "0x6000E86")]
		internal static void ResetStatics() { }

	}

	[Token(Token = "0x4000C82")]
	private static RankOverlay _open; //Field offset: 0x0
	[Token(Token = "0x4000CB5")]
	private const float ChromeHideDur = 0.2; //Field offset: 0x0
	[Token(Token = "0x4000CB6")]
	private const float ChromeShowDur = 0.18; //Field offset: 0x0
	[Token(Token = "0x4000CAB")]
	private static Sprite _topFade; //Field offset: 0x8
	[Token(Token = "0x4000CAC")]
	private static float _topFadeExp; //Field offset: 0x10
	[Token(Token = "0x4000CB2")]
	private static Sprite _arrowSprite; //Field offset: 0x18
	[Token(Token = "0x4000CB3")]
	private static bool _arrowLoaded; //Field offset: 0x20
	[Token(Token = "0x4000CB4")]
	private static bool _arrowFromAsset; //Field offset: 0x21
	[FieldOffset(Offset = "0x20")]
	[Token(Token = "0x4000C83")]
	private RankFxConfig _cfg; //Field offset: 0x20
	[FieldOffset(Offset = "0x28")]
	[Token(Token = "0x4000C84")]
	private WeeklyView _view; //Field offset: 0x28
	[FieldOffset(Offset = "0x30")]
	[Token(Token = "0x4000C85")]
	private int _before; //Field offset: 0x30
	[FieldOffset(Offset = "0x34")]
	[Token(Token = "0x4000C86")]
	private int _after; //Field offset: 0x34
	[FieldOffset(Offset = "0x38")]
	[Token(Token = "0x4000C87")]
	private int _flying; //Field offset: 0x38
	[FieldOffset(Offset = "0x40")]
	[Token(Token = "0x4000C88")]
	private CanvasGroup _group; //Field offset: 0x40
	[FieldOffset(Offset = "0x48")]
	[Token(Token = "0x4000C89")]
	private RectTransform _content; //Field offset: 0x48
	[FieldOffset(Offset = "0x50")]
	[Token(Token = "0x4000C8A")]
	private float _fitScale; //Field offset: 0x50
	[FieldOffset(Offset = "0x54")]
	[Token(Token = "0x4000C8B")]
	private Vector2 _layoutRootSize; //Field offset: 0x54
	[FieldOffset(Offset = "0x5C")]
	[Token(Token = "0x4000C8C")]
	private Vector2Int _layoutScreen; //Field offset: 0x5C
	[FieldOffset(Offset = "0x64")]
	[Token(Token = "0x4000C8D")]
	private Rect _layoutSafeArea; //Field offset: 0x64
	[FieldOffset(Offset = "0x78")]
	[Token(Token = "0x4000C8E")]
	private TMP_Text _timerText; //Field offset: 0x78
	[FieldOffset(Offset = "0x80")]
	[Token(Token = "0x4000C8F")]
	private int _lastTimerSec; //Field offset: 0x80
	[FieldOffset(Offset = "0x88")]
	[Token(Token = "0x4000C90")]
	private RectTransform _myRow; //Field offset: 0x88
	[FieldOffset(Offset = "0x90")]
	[Token(Token = "0x4000C91")]
	private TMP_Text _myValue; //Field offset: 0x90
	[FieldOffset(Offset = "0x98")]
	[Token(Token = "0x4000C92")]
	private RectTransform _myPillIcon; //Field offset: 0x98
	[FieldOffset(Offset = "0xA0")]
	[Token(Token = "0x4000C93")]
	private bool _done; //Field offset: 0xA0
	[FieldOffset(Offset = "0xA1")]
	[Token(Token = "0x4000C94")]
	private bool _closing; //Field offset: 0xA1
	[FieldOffset(Offset = "0xA4")]
	[Token(Token = "0x4000C95")]
	private int _seedArrived; //Field offset: 0xA4
	[FieldOffset(Offset = "0xA8")]
	[Token(Token = "0x4000C96")]
	private Sprite _seedSprite; //Field offset: 0xA8
	[FieldOffset(Offset = "0xB0")]
	[Token(Token = "0x4000C97")]
	private bool _doSwap; //Field offset: 0xB0
	[FieldOffset(Offset = "0xB8")]
	[Token(Token = "0x4000C98")]
	private RectTransform _swapBelow; //Field offset: 0xB8
	[FieldOffset(Offset = "0xC0")]
	[Token(Token = "0x4000C99")]
	private int _rankUpAmount; //Field offset: 0xC0
	[FieldOffset(Offset = "0xC4")]
	[Token(Token = "0x4000C9A")]
	private int _rankUpHops; //Field offset: 0xC4
	[FieldOffset(Offset = "0xC8")]
	[Token(Token = "0x4000C9B")]
	private int _rankUpFlow; //Field offset: 0xC8
	[FieldOffset(Offset = "0xCC")]
	[Token(Token = "0x4000C9C")]
	private int _rankUpFrom; //Field offset: 0xCC
	[FieldOffset(Offset = "0xD0")]
	[Token(Token = "0x4000C9D")]
	private int _rankUpShownFrom; //Field offset: 0xD0
	[FieldOffset(Offset = "0xD8")]
	[Token(Token = "0x4000C9E")]
	private readonly List<RectTransform> _passedRows; //Field offset: 0xD8
	[FieldOffset(Offset = "0xE0")]
	[Token(Token = "0x4000C9F")]
	private readonly List<RectTransform> _runwayRows; //Field offset: 0xE0
	[FieldOffset(Offset = "0xE8")]
	[Token(Token = "0x4000CA0")]
	private readonly List<RectTransform> _belowRows; //Field offset: 0xE8
	[FieldOffset(Offset = "0xF0")]
	[Token(Token = "0x4000CA1")]
	private RectTransform _rowsViewport; //Field offset: 0xF0
	[FieldOffset(Offset = "0xF8")]
	[Token(Token = "0x4000CA2")]
	private List<RankEntry> _fullBoard; //Field offset: 0xF8
	[FieldOffset(Offset = "0x100")]
	[Token(Token = "0x4000CA3")]
	private int _winStart; //Field offset: 0x100
	[FieldOffset(Offset = "0x104")]
	[Token(Token = "0x4000CA4")]
	private int _winEnd; //Field offset: 0x104
	[FieldOffset(Offset = "0x108")]
	[Token(Token = "0x4000CA5")]
	private int _shownCount; //Field offset: 0x108
	[FieldOffset(Offset = "0x110")]
	[Token(Token = "0x4000CA6")]
	private RectTransform _peekHolder; //Field offset: 0x110
	[FieldOffset(Offset = "0x118")]
	[Token(Token = "0x4000CA7")]
	private TMP_Text _myRankText; //Field offset: 0x118
	[FieldOffset(Offset = "0x120")]
	[Token(Token = "0x4000CA8")]
	private readonly object _rollId; //Field offset: 0x120
	[FieldOffset(Offset = "0x128")]
	[Token(Token = "0x4000CA9")]
	private float _rowsBandCenter; //Field offset: 0x128
	[FieldOffset(Offset = "0x130")]
	[Token(Token = "0x4000CAA")]
	private RectTransform _rowsContent; //Field offset: 0x130
	[FieldOffset(Offset = "0x138")]
	[Token(Token = "0x4000CAD")]
	private RankPageConfig _pageCfg; //Field offset: 0x138
	[FieldOffset(Offset = "0x140")]
	[Token(Token = "0x4000CAE")]
	private RectTransform _podium; //Field offset: 0x140
	[FieldOffset(Offset = "0x148")]
	[Token(Token = "0x4000CAF")]
	private float _rowsTopY; //Field offset: 0x148
	[FieldOffset(Offset = "0x14C")]
	[Token(Token = "0x4000CB0")]
	private float _bandBottomY; //Field offset: 0x14C
	[FieldOffset(Offset = "0x150")]
	[Token(Token = "0x4000CB1")]
	private bool _podiumFinalPending; //Field offset: 0x150
	[FieldOffset(Offset = "0x151")]
	[Token(Token = "0x4000CB7")]
	private bool _chromeHeld; //Field offset: 0x151

	[Token(Token = "0x170001FF")]
	private static Sprite ArrowSprite
	{
		[Address(RVA = "0x326E2D8", Offset = "0x326E2D8", Length = "0x174")]
		[Token(Token = "0x6000E71")]
		 get { } //Length: 372
	}

	[Token(Token = "0x170001FB")]
	public static bool IsClosing
	{
		[Address(RVA = "0x32661F4", Offset = "0x32661F4", Length = "0xCC")]
		[Token(Token = "0x6000E53")]
		 get { } //Length: 204
	}

	[Token(Token = "0x170001FA")]
	public static bool IsOpen
	{
		[Address(RVA = "0x3266168", Offset = "0x3266168", Length = "0x8C")]
		[Token(Token = "0x6000E52")]
		 get { } //Length: 140
	}

	[Token(Token = "0x170001FC")]
	private float Pitch
	{
		[Address(RVA = "0x3266460", Offset = "0x3266460", Length = "0x20")]
		[Token(Token = "0x6000E56")]
		 get { } //Length: 32
	}

	[Token(Token = "0x170001FD")]
	private float TapHintHeight
	{
		[Address(RVA = "0x326E1CC", Offset = "0x326E1CC", Length = "0x24")]
		[Token(Token = "0x6000E6C")]
		 get { } //Length: 36
	}

	[Token(Token = "0x170001FE")]
	private float TapHintY
	{
		[Address(RVA = "0x326E1F0", Offset = "0x326E1F0", Length = "0x48")]
		[Token(Token = "0x6000E6D")]
		 get { } //Length: 72
	}

	[Address(RVA = "0x32701C8", Offset = "0x32701C8", Length = "0x4C")]
	[Token(Token = "0x6000E83")]
	private static RankOverlay() { }

	[Address(RVA = "0x32700A8", Offset = "0x32700A8", Length = "0x120")]
	[Token(Token = "0x6000E82")]
	public RankOverlay() { }

	[Address(RVA = "0x3270214", Offset = "0x3270214", Length = "0x11C")]
	[CompilerGenerated]
	[Token(Token = "0x6000E84")]
	private void <Build>b__48_0() { }

	[Address(RVA = "0x326BD28", Offset = "0x326BD28", Length = "0x20")]
	[CompilerGenerated]
	[Token(Token = "0x6000E85")]
	internal static Vector2 <BuildPodium>g__ToLocal|69_0(Vector2 n, ref <>c__DisplayClass69_0 unnamed_param_1) { }

	[Address(RVA = "0x3269EF0", Offset = "0x3269EF0", Length = "0x4F0")]
	[Token(Token = "0x6000E5F")]
	private void ApplyPeekCut(RectTransform row) { }

	[Address(RVA = "0x326E64C", Offset = "0x326E64C", Length = "0x680")]
	[Token(Token = "0x6000E73")]
	private void ArrowBurst(RectTransform around) { }

	[Address(RVA = "0x3266718", Offset = "0x3266718", Length = "0x6B4")]
	[Token(Token = "0x6000E58")]
	private void Build() { }

	[Address(RVA = "0x326E44C", Offset = "0x326E44C", Length = "0x200")]
	[Token(Token = "0x6000E72")]
	private static Sprite BuildArrowSprite() { }

	[Address(RVA = "0x326728C", Offset = "0x326728C", Length = "0x750")]
	[Token(Token = "0x6000E64")]
	private void BuildPodium(RectTransform root, bool final) { }

	[Address(RVA = "0x326BD48", Offset = "0x326BD48", Length = "0x6B0")]
	[Token(Token = "0x6000E65")]
	private void BuildPodiumStand(RankEntry e, int rank, Vector2 anchor, RectTransform front, int myValue) { }

	[Address(RVA = "0x3269398", Offset = "0x3269398", Length = "0xB20")]
	[Token(Token = "0x6000E61")]
	private RectTransform BuildRow(RectTransform root, RankEntry e, bool isMe, bool outOfBoard) { }

	[Address(RVA = "0x32679DC", Offset = "0x32679DC", Length = "0x112C")]
	[Token(Token = "0x6000E59")]
	private void BuildRows(RectTransform root) { }

	[Address(RVA = "0x3269094", Offset = "0x3269094", Length = "0x304")]
	[Token(Token = "0x6000E5A")]
	private RectTransform BuildRowsViewport(RectTransform root, int rowCount) { }

	[Address(RVA = "0x326FDA4", Offset = "0x326FDA4", Length = "0x58")]
	[IteratorStateMachine(typeof(<ChromeRoots>d__103))]
	[Token(Token = "0x6000E7C")]
	private static IEnumerable<GameObject> ChromeRoots() { }

	[Address(RVA = "0x3266414", Offset = "0x3266414", Length = "0x4C")]
	[Token(Token = "0x6000E7D")]
	private void Close() { }

	[Address(RVA = "0x326FE70", Offset = "0x326FE70", Length = "0x74")]
	[IteratorStateMachine(typeof(<CloseCo>d__105))]
	[Token(Token = "0x6000E7E")]
	private IEnumerator CloseCo() { }

	[Address(RVA = "0x3266350", Offset = "0x3266350", Length = "0xC4")]
	[Token(Token = "0x6000E55")]
	public static void CloseOpen() { }

	[Address(RVA = "0x326A3E0", Offset = "0x326A3E0", Length = "0x94C")]
	[Token(Token = "0x6000E5B")]
	private void EnableBoardScroll() { }

	[Address(RVA = "0x326E2D8", Offset = "0x326E2D8", Length = "0x174")]
	[Token(Token = "0x6000E71")]
	private static Sprite get_ArrowSprite() { }

	[Address(RVA = "0x32661F4", Offset = "0x32661F4", Length = "0xCC")]
	[Token(Token = "0x6000E53")]
	public static bool get_IsClosing() { }

	[Address(RVA = "0x3266168", Offset = "0x3266168", Length = "0x8C")]
	[Token(Token = "0x6000E52")]
	public static bool get_IsOpen() { }

	[Address(RVA = "0x3266460", Offset = "0x3266460", Length = "0x20")]
	[Token(Token = "0x6000E56")]
	private float get_Pitch() { }

	[Address(RVA = "0x326E1CC", Offset = "0x326E1CC", Length = "0x24")]
	[Token(Token = "0x6000E6C")]
	private float get_TapHintHeight() { }

	[Address(RVA = "0x326E1F0", Offset = "0x326E1F0", Length = "0x48")]
	[Token(Token = "0x6000E6D")]
	private float get_TapHintY() { }

	[Address(RVA = "0x3268EB0", Offset = "0x3268EB0", Length = "0xA4")]
	[Token(Token = "0x6000E7A")]
	private void HideGameChrome() { }

	[Address(RVA = "0x3266DCC", Offset = "0x3266DCC", Length = "0x94")]
	[Token(Token = "0x6000E80")]
	private static string L(string key, string fallback) { }

	[Address(RVA = "0x326E238", Offset = "0x326E238", Length = "0x8")]
	[Token(Token = "0x6000E6E")]
	private void LateUpdate() { }

	[Address(RVA = "0x326B120", Offset = "0x326B120", Length = "0x72C")]
	[Token(Token = "0x6000E62")]
	private void MakeAvatar(RectTransform parent, RankEntry e, float size, Vector2 pos) { }

	[Address(RVA = "0x326CA18", Offset = "0x326CA18", Length = "0x560")]
	[Token(Token = "0x6000E67")]
	private void MakeCenteredPill(RectTransform parent, Vector2 size, float fontSize, int value, Vector2 pos) { }

	[Address(RVA = "0x326C3F8", Offset = "0x326C3F8", Length = "0x620")]
	[Token(Token = "0x6000E66")]
	private void MakeMedal(RectTransform parent, int rank, float size, Vector2 pos) { }

	[Address(RVA = "0x326FEE4", Offset = "0x326FEE4", Length = "0xCC")]
	[Token(Token = "0x6000E7F")]
	private void OnDestroy() { }

	[Address(RVA = "0x326AD2C", Offset = "0x326AD2C", Length = "0x2C")]
	[Token(Token = "0x6000E5C")]
	public void OnPointerClick(PointerEventData eventData) { }

	[Address(RVA = "0x326FFB0", Offset = "0x326FFB0", Length = "0xF8")]
	[Token(Token = "0x6000E81")]
	public static void PlayAccrualDemo(int gain = 5) { }

	[Address(RVA = "0x326B84C", Offset = "0x326B84C", Length = "0x4DC")]
	[Token(Token = "0x6000E63")]
	private RankEntry[] PodiumEntries(bool before, out int myStand) { }

	[Address(RVA = "0x3268FC8", Offset = "0x3268FC8", Length = "0xCC")]
	[Token(Token = "0x6000E77")]
	private static int RankFor(List<RankEntry> board, int value) { }

	[Address(RVA = "0x3268B08", Offset = "0x3268B08", Length = "0x3A8")]
	[Token(Token = "0x6000E6F")]
	private void RefreshLayout(bool force) { }

	[Address(RVA = "0x326CF78", Offset = "0x326CF78", Length = "0x2C4")]
	[Token(Token = "0x6000E68")]
	private void RefreshPodiumFinal() { }

	[Address(RVA = "0x32662C0", Offset = "0x32662C0", Length = "0x90")]
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType::SubsystemRegistration (4))]
	[Token(Token = "0x6000E54")]
	private static void ResetStatics() { }

	[Address(RVA = "0x326FDFC", Offset = "0x326FDFC", Length = "0x74")]
	[Token(Token = "0x6000E7B")]
	private void RestoreGameChrome(bool fade) { }

	[Address(RVA = "0x326E240", Offset = "0x326E240", Length = "0x98")]
	[IteratorStateMachine(typeof(<RollValue>d__83))]
	[Token(Token = "0x6000E70")]
	private IEnumerator RollValue(int from, int to, float dur) { }

	[Address(RVA = "0x326F288", Offset = "0x326F288", Length = "0x518")]
	[Token(Token = "0x6000E75")]
	private void RowEdgeGlow(RectTransform row) { }

	[Address(RVA = "0x326AD58", Offset = "0x326AD58", Length = "0xAC")]
	[Token(Token = "0x6000E5E")]
	private float RowRootY(RectTransform row) { }

	[Address(RVA = "0x3269EB8", Offset = "0x3269EB8", Length = "0x38")]
	[Token(Token = "0x6000E5D")]
	private float RowY(int k) { }

	[Address(RVA = "0x3268F54", Offset = "0x3268F54", Length = "0x74")]
	[IteratorStateMachine(typeof(<Sequence>d__74))]
	[Token(Token = "0x6000E69")]
	private IEnumerator Sequence() { }

	[Address(RVA = "0x3266480", Offset = "0x3266480", Length = "0x298")]
	[Token(Token = "0x6000E57")]
	public static void Show(WeeklyView view, int localAfterValue, int flyingSeeds) { }

	[Address(RVA = "0x326D23C", Offset = "0x326D23C", Length = "0xD80")]
	[Token(Token = "0x6000E6A")]
	private void ShowRankUpMessage() { }

	[Address(RVA = "0x326DFBC", Offset = "0x326DFBC", Length = "0x210")]
	[Token(Token = "0x6000E6B")]
	private void ShowTapHint() { }

	[Address(RVA = "0x326F7A0", Offset = "0x326F7A0", Length = "0x5FC")]
	[Token(Token = "0x6000E76")]
	private void SparkleBurst(RectTransform around) { }

	[Address(RVA = "0x326ECCC", Offset = "0x326ECCC", Length = "0x5BC")]
	[Token(Token = "0x6000E74")]
	private void SparklePopAtPill() { }

	[Address(RVA = "0x326AE04", Offset = "0x326AE04", Length = "0x31C")]
	[Token(Token = "0x6000E60")]
	private static Sprite TopFadeSprite(float exponent) { }

	[Address(RVA = "0x326FD9C", Offset = "0x326FD9C", Length = "0x8")]
	[Token(Token = "0x6000E78")]
	private void Update() { }

	[Address(RVA = "0x3266E60", Offset = "0x3266E60", Length = "0x42C")]
	[Token(Token = "0x6000E79")]
	private void UpdateTimer(bool force) { }

}

