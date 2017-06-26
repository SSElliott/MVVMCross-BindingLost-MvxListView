
using MvvmCross.Platform.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Converters
{
 
    public enum WorkOrder_Status
    {
        Awaiting_Approval = 1,
        New = 2,
        Scheduled = 3,
        In_Progress = 4,
        On_Hold = 5,
        Closed = 6,
        Rejected = 7,
        NotDone = 8
    }





    public class Statusconverter : MvxValueConverter<int, string>
    {

        protected override string Convert(int value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           
            switch (value)
            {
                case 2:
                    {
                        return "New";
                    }
                case 3:
                    {
                        return "Scheduled";
                    }
                case 4:
                    {
                        return "In Progress";
                    }
                case 5:
                    {
                        return "On Hold";
                    }
                case 6:
                    {
                        return "Closed";
                    }
                case 8:
                    {
                        return "Not Done";
                    }
            }
            return "";

        }
    }
}
