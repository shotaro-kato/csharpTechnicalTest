using csharpTechnicalTest.ViewModel;

namespace csharpTechnicalTest.Command
{
    /// <summary>
    /// 入力値クリアコマンド定義クラス
    /// </summary>
    public class ClearCommand : AbstractCommand
    {
        /// <summary>
        /// 入力クリア後の初期値
        /// </summary>
        private const string defaultOutputValue = "0";

        /// <summary>
        /// 初期画面のViewModelプロパティ
        /// </summary>
        private MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// コマンド実行処理で使用する ViewModel を保持するためのコンストラクタ
        /// </summary>
        /// <param name="mainWindowViewModel">初期画面のViewModel</param>
        public ClearCommand(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
        }

        /// <summary>
        /// AbstractCommandt抽象クラスから継承されたコマンド実行処理
        /// </summary>
        /// <param name="parameter">コマンド実行時に画面から渡されるデータ</param>
        public override void Execute(object? parameter)
        {
            // 入力値
            string? inputParameter = (string?)parameter;
            // 入力値がnullである場合
            if (inputParameter == null)
            {
                // 処理しない
                return;
            }
            // 入力値が AC である場合
            if ("AC".Equals(inputParameter))
            {
                // 四則演算結果を消去
                MainWindowViewModel.Calculator.CalcResult = 0;
            }

            // 画面に表示させる初期値を再設定
            MainWindowViewModel.OutputValue = defaultOutputValue;

            // 数値入力状態を false に設定
            MainWindowViewModel.IsClickedCalcInputButton = false;
        }
    }
}
