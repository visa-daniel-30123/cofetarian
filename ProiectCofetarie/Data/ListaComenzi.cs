using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProiectCofetarie.Data
{
    public class ListaComenzi : ObservableCollection<string>
    {
        public int pretfinal = 0;

        public void crestecomanda(int n)
        {
            pretfinal += n;
        }
        public int getpretfinal() {  return pretfinal; }
        public void setpretfinal(int n) {  pretfinal = n; }
    }
}
