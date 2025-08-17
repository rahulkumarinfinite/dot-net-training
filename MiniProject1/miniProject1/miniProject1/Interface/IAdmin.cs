using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniProject1.Interface
{
    interface IAdmin
    {
        void ReservationReport();
        void CancelReport();
        void UpdateTrain();
        void AddTrain();
        void DeleteTrain();

    }
}
