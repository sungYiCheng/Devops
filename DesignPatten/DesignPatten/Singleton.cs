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
         * 解決什麼問題？
         * 1. 集中管理
         * 2. 共享全域變數
         * 
         * 使用時機: 
         * 
         * 在系統當中，有些功能是高度共享的，如果這時候採用單例模式，就會便於管理。譬如 logger 或是 cache，不管是誰呼叫了這些實例或功能，都被集中管理，以避免不同實例各自操作所可能產生的 concurrent 問題
         * 
         * 
         * 優點:
         *  從應用程式生命週期開始至結束，應保證只能取到一個且相同的實例（物件）
         *  可以集中管理資料、操作行為。
            因第 1 點關係，故可減少創造實例的開銷（記憶體浪費）
            與全域變數不同的是該模式可以延遲實例初始化（Lazy initialization），但在部分程式語言實作該模式時，仍要注意是否有同步（Synchronize）問題發生
         * 
         * 壞處
         * 
         * 它違反了單一功能原則，因為他控制了確保只有一個實例的產生，以及實例的實作
         * 也因為集中管理，導致擴展性不佳，如果有任何的新需求進入，都必須更改這個類別當中的實作方式
         * 可能會隱藏了它與其他類別的關係，因為對於使用者來說，只要直接取用實例就行，但如果要理解功能是如何實作，就必須進入這個類別的程式碼查看，無法透過相對外顯的繼承、參數傳遞等方式來更快理解。
         * 沒寫好，需要注意多線程的情況
         * 
         */


        public class Singleton
        {
            private static Singleton _instance;
            private static object _lock = new object();   // 加上鎖，避免多執行續下，因為時間差而導致被new出兩個

            public static Singleton Instance 
            {     
                get 
                { 
                    if (_instance == null)
                    {
                        lock (_lock)
                        {
                            if (_instance == null)
                            {
                                _instance = new Singleton();
                            }
                        }
                    }

                    return _instance; 
                } 
            }

            private Singleton() { }   // 設定 private 的 建構子，避免有其他類別有操作的機會

        }
    }
}
