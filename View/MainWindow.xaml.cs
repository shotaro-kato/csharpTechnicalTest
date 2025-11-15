using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace csharpTechnicalTest
{
    /// <summary>
    /// 初期画面
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 画面初期化
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            // 全テキストボックスにキー入力イベントハンドラーを登録
            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.KeyDownEvent, new KeyEventHandler(OnKeyDown));
            // 全ボタンにキー入力イベントハンドラーを登録
            EventManager.RegisterClassHandler(typeof(Button), UIElement.KeyDownEvent, new KeyEventHandler(OnKeyDown));
            // 初期フォーカスを「＝」ボタンに設定
            buttonEqual.Focus();
        }

        /// <summary>
        /// キー入力イベント処理
        /// </summary>
        /// <param name="sender">イベント発生コントロール情報</param>
        /// <param name="e">入力キー情報</param>
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                // Enter
                case Key.Enter:
                    // 「＝」コマンド実行
                    buttonEqual.Command.Execute(buttonEqual.CommandParameter);
                    // 既存のEnterキー入力機能（フォーカスが当たっているコントロール実行機能）を無効化
                    e.Handled = true;
                    break;
                // +
                case Key.OemPlus:
                    // 「+」コマンド実行
                    buttonAdd.Command.Execute(buttonAdd.CommandParameter);
                    break;
                // -
                case Key.OemMinus:
                    // 「-」コマンド実行
                    buttonSub.Command.Execute(buttonSub.CommandParameter);
                    break;
                // ÷
                case Key.OemBackslash:
                    // 「÷」コマンド実行
                    buttonDiv.Command.Execute(buttonDiv.CommandParameter);
                    break;
                // X
                case Key.OemAttn:
                    // 「X」コマンド実行
                    buttonMulti.Command.Execute(buttonMulti.CommandParameter);
                    break;
                // .
                case Key.OemPeriod:
                    // 「.」コマンド実行
                    buttonPoint.Command.Execute(buttonPoint.CommandParameter);
                    break;
                // 0
                case Key.D0:
                    // 「0」コマンド実行
                    button0.Command.Execute(button0.CommandParameter);
                    break;
                // 1
                case Key.D1:
                    // 「1」コマンド実行
                    button1.Command.Execute(button1.CommandParameter);
                    break;
                // 2
                case Key.D2:
                    // 「2」コマンド実行
                    button2.Command.Execute(button2.CommandParameter);
                    break;
                // 3
                case Key.D3:
                    // 「3」コマンド実行
                    button3.Command.Execute(button3.CommandParameter);
                    break;
                // 4
                case Key.D4:
                    // 「4」コマンド実行
                    button4.Command.Execute(button4.CommandParameter);
                    break;
                // 5
                case Key.D5:
                    // 「5」コマンド実行
                    button5.Command.Execute(button5.CommandParameter);
                    break;
                // 6
                case Key.D6:
                    // 「6」コマンド実行
                    button6.Command.Execute(button6.CommandParameter);
                    break;
                // 7
                case Key.D7:
                    // 「7」コマンド実行
                    button7.Command.Execute(button7.CommandParameter);
                    break;
                // 8
                case Key.D8:
                    // 「8」コマンド実行
                    button8.Command.Execute(button8.CommandParameter);
                    break;
                // 9
                case Key.D9:
                    // 「9」コマンド実行
                    button9.Command.Execute(button9.CommandParameter);
                    break;
            }
        }
    }
}