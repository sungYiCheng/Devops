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
         * 使用時機: 
         * 
         * 透過類別建立出實例的時候，其實感覺就像是一個工廠生產出了產品。而同一個工廠 (類別)，可以生產出無限多個同樣者產品 (實例)。
         * 
         * 
         * 優點:
         * 
         * 使用者能夠快速從工廠取出需要的實例來使用，不需要自己去找目標類別來建立實例
         * 使用者也不需要管這些實例是怎麼被建立的，只要負責使用就行
         * 實作方式簡單好懂，能夠快速上手
         * 
         * 
         * 壞處
         * 
         * 新增一個新的商品，就必須要回去修改 Factory 當中的程式碼，有可能會影響到舊有的程式碼
         * 簡單工廠集中了所有建立實例的邏輯與責任，一旦不能正常運作，那麼所有產品都會受到影響
         * 
         * 
         */


        public class SimpleFactory
        {
            
        }
    }
}
