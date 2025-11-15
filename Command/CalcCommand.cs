using csharpTechnicalTest.ViewModel;
using static csharpTechnicalTest.Model.Calculator;

namespace csharpTechnicalTest.Command
{
    /// <summary>
    /// 四則演算子入力コマンド定義クラス
    /// </summary>
    public class CalcCommand : AbstractCommand
    {
        /// <summary>
        /// 初期画面のViewModelプロパティ
        /// </summary>
        private MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// コマンド実行処理で使用する ViewModel を保持するためのコンストラクタ
        /// </summary>
        /// <param name="mainWindowViewModel">初期画面のViewModel</param>
        public CalcCommand(MainWindowViewModel mainWindowViewModel)
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

            // 前回入力された四則演算子を元に四則演算処理を実行
            MainWindowViewModel.Calculator.CalcExecute(MainWindowViewModel.Status, decimal.Parse(outputValue));

            // 今回入力された四則演算子を保持
            switch(inputParameter)
            {
                case "＋":
                    MainWindowViewModel.Status = ArithmeticOperation.ADDITION;
                    break;
                case "－":
                    MainWindowViewModel.Status = ArithmeticOperation.SUBTRACTION;
                    break;
                case "Ｘ":
                    MainWindowViewModel.Status = ArithmeticOperation.MULTIPLICATION;
                    break;
                case "÷":
                    MainWindowViewModel.Status = ArithmeticOperation.DIVISION;
                    break;
                case "＝":
                    MainWindowViewModel.Status = ArithmeticOperation.NONE;
                    break;
            }

            // 入力値が ＝ である場合
            if ("＝".Equals(inputParameter))
            {
                // 四則演算結果を画面に表示
                MainWindowViewModel.OutputValue = string.Format("{0,20}", MainWindowViewModel.Calculator.CalcResult);
            }

            // 数値入力状態を false に設定
            MainWindowViewModel.IsClickedCalcInputButton = false;
        }
    }
}
