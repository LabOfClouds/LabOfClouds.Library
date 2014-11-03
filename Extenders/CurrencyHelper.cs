using LabOfClouds.Library.WebServices;
using System;

namespace LabOfClouds.Library.Extenders
{
    public static class CurrencyHelper
    {
        public static decimal DolarToReal(this decimal value)
        {
            var cotacaoDolar = new FachadaWSSGSClient();
            var values = cotacaoDolar.getUltimosValoresSerieVO(1, 1);
            var last = values.valores[0];
            var dolar = decimal.Parse(last.svalor.Replace(".", ","));

            return Decimal.Round(value * dolar, 2);
        }
    }
}