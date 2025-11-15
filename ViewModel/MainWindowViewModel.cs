using csharpTechnicalTest.Command;
using csharpTechnicalTest.Model;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using static csharpTechnicalTest.Model.Calculator;

namespace csharpTechnicalTest.ViewModel
{
    /// <summary>
    /// 初期画面のViewModelクラス
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// 画面入力値プロパティ
        /// </summary>
        private string InputValue { get; set; } = "0";

        /// <summary>
        /// <para>直前の数値入力ボタン押下状態</para>
        /// <para>※数値入力時の前回表示内容初期化判定に使用</para>
        /// <para>true : 直前に数値入力ボタンが押された, false : 直前に数値入力ボタン以外が押された</para>
        /// </summary>
        public bool IsClickedCalcInputButton { get; set; } = true;

        /// <summary>
        /// 四則演算プロパティ
        /// </summary>
        public Calculator Calculator { get; set; }

        /// <summary>
        /// メモリ機能プロパティ
        /// </summary>
        public Memory Memory { get; set; }

        /// <summary>
        /// 画面にバインドされるメモリ機能コマンドプロパティ
        /// </summary>
        public MemoryCommand MemoryCommand { get; set; }

        /// <summary>
        /// 画面にバインドされる数値入力コマンドプロパティ
        /// </summary>
        public NumberCommand NumberCommand { get; private set; }

        /// <summary>
        /// 画面にバインドされる入力値クリアコマンドプロパティ
        /// </summary>
        public ClearCommand ClearCommand { get; private set; }

        /// <summary>
        /// 画面にバインドされる四則演算子入力コマンドプロパティ
        /// </summary>
        public CalcCommand CalcCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// ModelクラスとCommandクラスのインスタンスを生成するためのコンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            Calculator = new Calculator();
            Memory = new Memory();
            MemoryCommand = new MemoryCommand(this);
            NumberCommand = new NumberCommand(this);
            ClearCommand = new ClearCommand(this);
            CalcCommand = new CalcCommand(this);
        }

        /// <summary>
        /// 画面にバインドされる表示値
        /// </summary>
        public string OutputValue
        {
            get
            {
                // 画面入力値を表示
                return InputValue;
            }
            set
            {
                // 画面入力値を保持
                InputValue = value;

                // 値変更イベント定義
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MainWindowViewModel.OutputValue)));
            }
        }

        /// <summary>
        /// 計算状態
        /// <para>（初期値：NONE）</para>
        /// </summary>
        public ArithmeticOperation Status { get; set; } = ArithmeticOperation.NONE;

    }
}
