﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;


namespace WPF_CityFlora.ViewModel
{
    class ArithmeticConverter : IValueConverter
    {
        private const string ArithmeticParseExpression = "([+\\-*/]{1,1})\\s{0,}(\\-?[\\d\\.]+)";
        private Regex arithmeticRegex = new Regex(ArithmeticParseExpression);

        #region IValueConverter Members

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value is double && parameter != null)
            {
                string param = parameter.ToString();

                if (param.Length > 0)
                {
                    Match match = arithmeticRegex.Match(param);
                    if (match != null && match.Groups.Count == 3)
                    {
                        string operation = match.Groups[1].Value.Trim();
                        string numericValue = match.Groups[2].Value;

                        double number = 0;
                        if (double.TryParse(numericValue,
                                            System.Globalization.NumberStyles.Float,
                                            CultureInfo.InvariantCulture.NumberFormat,   // damit auch bei uns 0.5 funktioniert
                                            out number)) // this should always succeed or our regex is broken
                        {
                            double valueAsDouble = (double)value;
                            double returnValue = 0;

                            switch (operation)
                            {
                                case "+":
                                    returnValue = valueAsDouble + number;
                                    break;

                                case "-":
                                    returnValue = valueAsDouble - number;
                                    break;

                                case "*":
                                    returnValue = valueAsDouble * number;
                                    break;

                                case "/":
                                    returnValue = valueAsDouble / number;
                                    break;
                            }

                            return returnValue;
                        }
                    }
                }
            }

            return null;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
