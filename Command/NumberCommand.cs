using csharpTechnicalTest.ViewModel;

namespace csharpTechnicalTest.Command
{
    /// <summary>
    /// 数値入力コマンド定義クラス
    /// </summary>
    public class NumberCommand : AbstractCommand
    {
        /// <summary>
        /// 初期画面のViewModelプロパティ
        /// </summary>
        private MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// コマンド実行処理で使用する ViewModel を保持するためのコンストラクタ
        /// </summary>
        /// <param name="mainWindowViewModel">初期画面のViewModel</param>
        public NumberCommand(MainWindowViewModel mainWindowViewModel)
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
            string outputValue = MainWindowViewModel.OutputValue.Trim();
            // 入力値
            string? inputParameter = (string?)parameter;
            // 画面表示値が 0 であるかの判定結果
            bool isOutputZeroValue = "0".Equals(MainWindowViewModel.OutputValue);
            // 入力値が「.」であるかの判定結果
            bool isInputPointValue = ".".Equals(inputParameter);

            // 画面表示値が20桁以上である、または、入力値がnullである場合
            if (outputValue.Length >= 20 || inputParameter == null)
            {
                // 処理しない
                return;
            }
            // 画面に表示されている値が 0 である、かつ、入力値の一番左の文字が 0 である場合
            if (isOutputZeroValue && inputParameter.ToString()[0].Equals('0'))
            {
                // 処理しない
                return;
            }
            // 入力値が「.」である、かつ、
            // 画面に表示されている値に「.」が含まれている場合
            if (isInputPointValue && outputValue.Contains('.'))
            {
                // 処理しない
                return;
            }

            // 画面に表示されている値が 0 である、かつ、入力値が「.」である場合
            // または
            // 画面に表示されている値が 0 以外である、かつ、前回押されたボタンが数値である場合
            if ( (isOutputZeroValue && isInputPointValue) ||
                 (!isOutputZeroValue && MainWindowViewModel.IsClickedCalcInputButton) )
            {
                // 画面表示値の右側に入力値を挿入
                outputValue += inputParameter;
            }
            else
            {
                // 入力値をそのまま画面表示
                outputValue = inputParameter;
            }

            // 画面に表示させる値を再設定
            MainWindowViewModel.OutputValue = outputValue;

            // 数値入力状態を true に設定
            MainWindowViewModel.IsClickedCalcInputButton = true;
        }
    }
}
