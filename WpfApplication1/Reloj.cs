using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    [Serializable()]
    public class Reloj 
    {
        /// getter y setter
        public String data { get; set; }
        //Constructor 
        public Reloj(String data)
        {
            this.data = data;
        }
        public Reloj()
            {
            }
    }
}
