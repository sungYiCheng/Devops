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
         * 有些時候我們因應外在環境的變動，需要產出類似的、但是又截然不同的實例（譬如棒球選手和網球選手），但又要避免像簡單工廠那樣，因集中生產所造成的維護和擴充問題，最後這裡我們透過「抽象」的方式來解決問題。
         * 首先是建立一個介面（或是類別也可以）來定義各個工廠的實作要求 (譬如 trainAthlete 方法)，但是不定義詳細的實作方式。
         * 接著，讓不同的產品建立相對應不同的工廠，並各自執行 trainAthlete 方法。譬如 BaseballPlayerFactory 的做法就是呼叫 new BaseballPlayer()。
         * 最後，使用者根據需求，呼叫需要的工廠來生產實例。
         * 
         * 
         * 優點:
         * 
         * 相對於簡單工廠模式，工廠模式的好處是滿足了「單一功能原則」，讓 AthleteFactory 只管要有什麼方法，而不用管實作細節
         * 滿足了「開放封閉原則」，未來有任何新的需求出現，只要按照介面（或類別）設計新的工程即可，大大提升了維護性和擴充性。
         * 
         * 
         * 壞處
         * 
         * 每當有新需求出現，我們就需要建立一個新的工廠 (e.g., xxxFactory)，以及負責生產實例的類別，兩者會成雙成對出現
         * 
         * 
         */


        public class Factory
        {
            
        }
    }
}
