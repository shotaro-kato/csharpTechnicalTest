namespace csharpTechnicalTest.Model
{
    /// <summary>
    /// 四則演算し、その計算結果を保持するためのModelクラス
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// 四則演算中の状態定義
        /// </summary>
        public enum ArithmeticOperation
        {
            NONE,           // 未演算
            ADDITION,       // 加算中
            SUBTRACTION,    // 減算中
            MULTIPLICATION, // 乗算中
            DIVISION,       // 除算中
        }

        /// <summary>
        /// 計算結果の値
        /// <para>（初期値：０）</para>
        /// </summary>
        public decimal CalcResult { get; set; } = 0;

        /// <summary>
        /// 四則演算処理
        /// </summary>
        /// <param name="status">四則演算子</param>
        /// <param name="inputValue">画面入力値（右被演算子）</param>
        public void CalcExecute(ArithmeticOperation status, decimal inputValue)
        {
            switch (status)
            {
                case ArithmeticOperation.NONE:
                    CalcResult = inputValue;
                    break;
                case ArithmeticOperation.ADDITION:
                    CalcResult += inputValue;
                    break;
                case ArithmeticOperation.SUBTRACTION:
                    CalcResult -= inputValue;
                    break;
                case ArithmeticOperation.MULTIPLICATION:
                    CalcResult *= inputValue;
                    break;
                case ArithmeticOperation.DIVISION:
                    CalcResult /= inputValue;
                    break;
            }
        }
    }
}
