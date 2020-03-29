using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Probability
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ComplexEvRunner evr1 = new ComplexEvRunner(new List<Event>(){
                new Event(1, 2), new Event(1, 3), new Event(1, 3), new Event("NamedDice", 1, 2) });
            CheckMethods cm = new CheckMethods(evr1.checkSMIN);
            cm += new CheckMethods(evr1.checkFMIN);
            evr1.setChecks(cm, new List<int> { 2, 1 });
            evr1.Name = "Bollocks!";

            SimpleEvRunner evr2 = new SimpleEvRunner(new Event(1, 5), 0, 2);

            Application.Run(new ComplexEvForm(new ComplexEvRunner(new List<EventRunner>() { evr1, evr2 })));
        }
    }
}
