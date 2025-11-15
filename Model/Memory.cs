namespace csharpTechnicalTest.Model
{
    /// <summary>
    /// メモリ機能を実装するためのModelクラス
    /// </summary>
    public class Memory
    {
        /// <summary>
        /// メモリに対する演算方法の定義
        /// </summary>
        public enum MemoryOperation
        {
            ADDITION,       // 加算
            SUBTRACTION,    // 減算
        }

        /// <summary>
        /// メモリの値
        /// <para>（初期値：０）</para>
        /// </summary>
        public decimal MemoryValue { get; set; } = 0;

        /// <summary>
        /// メモリ演算処理
        /// </summary>
        /// <param name="status">メモリに対する演算方法</param>
        /// <param name="value">演算対象値（右被演算子）</param>
        public void CalcExecute(MemoryOperation status, decimal value)
        {
            switch (status)
            {
                case MemoryOperation.ADDITION:
                    MemoryValue += value;
                    break;
                case MemoryOperation.SUBTRACTION:
                    MemoryValue -= value;
                    break;
            }
        }
    }
}
