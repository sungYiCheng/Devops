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
命令模式當中，我們將請求本身封裝成一個物件，並且將「接受請求」和「執行請求」兩件事情分開處理。

如果以現實生活中的例子來看，在比較有一點規模的餐廳當中，「處理客人點餐」和「實際準備餐點」是不同的人，譬如服務生 (server) 以及廚師 (chef)
         * 
         * 
         * 優點與缺點
命令模式的優點在於，我們「接收請求」、「執行請求」兩個不同的關注點分離。而當我們有專門負責「接收請求」的角色出現之後，就可以在實際執行之前，預先做不同的處理，譬如

安排請求處理的行程
決定接受或拒絕請求
決定重做或撤銷請求
不過當然缺點就是，程式碼會比原本的複雜許多囉
         * 
         * 
         * 
         * 
         */


        public class Commnad
        {
            
        }
    }
}
