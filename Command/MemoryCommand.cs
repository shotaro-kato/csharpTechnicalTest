using csharpTechnicalTest.ViewModel;
using static csharpTechnicalTest.Model.Memory;

namespace csharpTechnicalTest.Command
{
    /// <summary>
    /// メモリ機能コマンド定義クラス
    /// </summary>
    public class MemoryCommand : AbstractCommand
    {
        /// <summary>
        /// 初期画面のViewModelプロパティ
        /// </summary>
        private MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// コマンド実行処理で使用する ViewModel を保持するためのコンストラクタ
        /// </summary>
        /// <param name="mainWindowViewModel">初期画面のViewModel</param>
        public MemoryCommand(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
        }

        /// <summary>
        /// AbstractCommandt抽象クラスから継承されたコマンド実行処理
        /// </summary>
        /// <param name="parameter">コマンド実行時に画面から渡されるデータ</param>
        public override void Execute(object? parameter)
        {
            // 画面に表示されている値を取得
            string outputValue = MainWindowViewModel.OutputValue;
            // 入力値
            string? inputParameter = (string?)parameter;
            // 入力値がnullである場合
            if (inputParameter == null)
            {
                // 処理しない
                return;
            }

            // 入力されたメモリ機能ボタンによって処理を分岐
            switch(inputParameter)
            {
                // メモリ加算処理
                case "M+":
                    // 前回入力された四則演算子を元に四則演算処理を実行
                    MainWindowViewModel.Calculator.CalcExecute(MainWindowViewModel.Status, decimal.Parse(outputValue));
                    // メモリ演算処理を実行
                    MainWindowViewModel.Memory.CalcExecute(MemoryOperation.ADDITION, MainWindowViewModel.Calculator.CalcResult);
                    break;
                // メモリ減算処理
                case "M-":
                    // 前回入力された四則演算子を元に四則演算処理を実行
                    MainWindowViewModel.Calculator.CalcExecute(MainWindowViewModel.Status, decimal.Parse(outputValue));
                    // メモリ演算処理を実行
                    MainWindowViewModel.Memory.CalcExecute(MemoryOperation.SUBTRACTION, MainWindowViewModel.Calculator.CalcResult);
                    break;
                // メモリ表示処理
                case "MRC":
                    MainWindowViewModel.OutputValue = string.Format("{0,20}", MainWindowViewModel.Memory.MemoryValue);
                    break;
            }

            // 数値入力状態を false に設定
            MainWindowViewModel.IsClickedCalcInputButton = false;
        }
    }
}
