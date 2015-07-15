﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OperatorOverloading.Interfaces
{
    /*IParser is a interface which consist of parseFile method.
     * this interface is implemented by the ParseJSON class.*/
    public interface IParser
    {
        Dictionary<string, double> ParseFile(string builder);
    }
}
