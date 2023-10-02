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
         * 最大的目的在於，將兩個「不同介面」的物件組合在一起
         * 
         * 
         * 優點與缺點
        使用轉接器的優點是，可以讓原本兩個類別都專注在自己的功能上面，不需要去管因為他人使用而造成的介面轉接問題。
        然而缺點是，如果我們已經很確定使用者是誰，那麼其實我們可以直接轉換成使用者需要的介面，也就不需要額外創造一個新的轉接器來使用。

        轉接器模式提供了一個快速解決問題的方案，但在穩定、可期待的使用場景之中，轉接器看起來就沒有那麼必要了。
         * 
         */


        public class Adaptor
        {
            
        }
    }
}
