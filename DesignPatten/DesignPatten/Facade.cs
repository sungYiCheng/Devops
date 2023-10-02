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
         * 用一個"物件"把所有的複雜方法都打包起來，只提供給使用者簡單的操作(內部由不同方法組成)，彷彿使用者只看到外觀就可以使用
         * 
         * 
        優點與缺點
        這個模式的內容其實很容易理解，實作方式也相當的簡單。而外觀模式常見的地方不僅僅只在於包裝複雜的函式，很多時候也會包裝整個應用程式當中的子系統，讓程式碼的操作本身更為簡潔。
        對使用者來說，可以不用去知道背後系統的實作細節。

        但缺點就是，我們將許多的操作都放在同一個地方，因此實作外觀模式的這個物件將會越來越大。
         * 
         * 
         */


        public class Facade
        {

        }
    }
}
