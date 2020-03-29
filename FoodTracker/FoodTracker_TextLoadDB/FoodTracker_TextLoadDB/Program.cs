using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodTracker_TextLoadDB
{
    static class Program
    {
        /// <summary>
        /// Program aimed primarily at Loading Information to and from Text Files about Food Consumed in a number of days with meals and food entries.
        /// Also uses this Information to load data to and from a MSSQL database.
        /// Also has an interface to allow the introduction of new foodtracking data from the user and saving it(to be put either in text files or database)
        /// The Classes created were Purely Designed from the format of the Text Files. NOT the database object. Methods for database were INTENTIONALLY created to make--
        /// --the bridge between the DB and program Class WITHOUT Changing the structure of the classes. The database part is mostly strickly here to populate--
        /// --Already Existing stuff into the DB for further use. The DB is designed to be used by another application/system. (this is mostly for quick personal use &practice)
        /// </summary>
        [STAThread]
        static void Main()  //program starts here
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
