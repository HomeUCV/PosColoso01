using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDatos;


namespace CapaNegocio
{
   public class BackupNE
    {

        BackupDAO b = new BackupDAO();

        public String Backup_Minimarket()
        {
            return b.BackupeMinimarket();
        }
    }
}
