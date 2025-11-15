using System.Windows.Input;

namespace csharpTechnicalTest.Command
{
    /// <summary>
    /// コマンド定義クラスにおけるICommandインターフェースの共通処理を実装するための抽象クラス
    /// </summary>
    public abstract class AbstractCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);
    }
}
