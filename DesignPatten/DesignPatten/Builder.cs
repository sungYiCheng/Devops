using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatten
{
    internal partial class DesignPatten
    {
        /*
         * 
         * 避免 創造物件時，參數過多雜亂的情況
         * 
         * 把所有參數的生成都獨立出來 (builder)
         * 
         * 最後再由一個中控(director) 設定不同的物件需要用哪一些 參數的生成 來組合而成
         * 
         * 
         * 
         * 跟工廠模式相比
工廠模式專注在產出的結果，而建造者模式較多關注在生產的步驟、組合和順序上面。另一方面，工廠模式產出的產品為同一（或類似）性質的產品，但透過建造者模式，我們可以創造出非常多變化的產品
         * 
         */


        public class Builder
        {
            
        }
    }
}
