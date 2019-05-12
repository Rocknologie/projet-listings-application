using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Listings_Schmidt_Surieux.Interfaces
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
