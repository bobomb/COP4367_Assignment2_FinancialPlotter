using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
namespace Graphing_Demo
{
    /// <summary>
    /// Grabs financial data from yahoo
    /// </summary>
    class SymbolDataGrabber
    {
        static string SymbolRequestUrl = @"http://ichart.finance.yahoo.com/table.csv?s={0}&g=d&ignore=.csv";
        static string CompanyNameRequestUrl = @"http://finance.yahoo.com/d/quotes.csv?s={0}&f=sn";
        public static SymbolData GetSymbolData(string ticker)
        {
            //create web request
            try
            {
                SymbolData data = new SymbolData();
                data.TickerName = ticker;
                //first request company name
                WebRequest companyRequest = WebRequest.Create(String.Format(CompanyNameRequestUrl, ticker));;
                WebResponse companyResponse = companyRequest.GetResponse();
                HttpWebResponse httpCompanyResponse = (HttpWebResponse)companyResponse;
                String companyName = ProcessCompanyResponse(companyResponse);
                Debug.WriteLine(String.Format("COMPANY NAME: {0}", companyName));
                data.CompanyName = companyName;
                               
                WebRequest symbolRequest = WebRequest.Create(String.Format(SymbolRequestUrl, ticker));
                WebResponse symbolResponse = symbolRequest.GetResponse();
                HttpWebResponse httpSymbolResponse = (HttpWebResponse)symbolResponse;
                data.Data = ProcessSymbolResponse(symbolResponse);

                return data;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        private static List<SymbolDataEntry> ProcessSymbolResponse(WebResponse symbolResponse)
        {
            List<SymbolDataEntry> symbolDataList = new List<SymbolDataEntry>();
            Stream dataStream = symbolResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Debug.WriteLine("***********ProcessSymbolResponse");
            Debug.WriteLine(responseFromServer);
            String[] rows = responseFromServer.Split('\n');
            Debug.WriteLine(rows.Length);
            if (rows.Length > 1)
            {
                for (int i = 1; i < rows.Length; i++)
                {
                    string row = rows[i];
                    var splitRows = row.Split(',');
                    Debug.WriteLine(String.Format("Formatted split row has {0} elements", splitRows.Length));
                    if (splitRows.Length == 7)
                    {

                        DateTime date = DateTime.Parse(splitRows[0]);
                        float open = float.Parse(splitRows[1]);
                        float high = float.Parse(splitRows[2]);
                        float low = float.Parse(splitRows[3]);
                        float close = float.Parse(splitRows[4]);
                        long volume = long.Parse(splitRows[5]);
                        float adjustedClose = float.Parse(splitRows[6]);
                        symbolDataList.Add(new SymbolDataEntry(date, open, close, high, low, volume, adjustedClose));
                    }
                }
            }
            return symbolDataList;
        }

        private static string ProcessCompanyResponse(WebResponse companyResponse)
        {
            Stream dataStream = companyResponse.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Debug.WriteLine(responseFromServer);
            string s = responseFromServer;
            String pattern = ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))";
            Regex parseExpression = new Regex(pattern);
            Debug.WriteLine("***********");
            return parseExpression.Split(responseFromServer).Last().Replace("\"", "");
        }
    }

    public class SymbolData
    {
        public string TickerName;
        public string CompanyName;
        public List<SymbolDataEntry> Data;
    }

    //holds each row from the CSV
    public struct SymbolDataEntry
    {
        DateTime Date;
        float Open;
        float Close;
        float High;
        float Low;
        long Volume;
        float AdjustedClose;

        public SymbolDataEntry(DateTime date, float open, float close, float high, float low, long volume, float adjustedClose)
        {
            Date = date;
            Open = open;
            Close = close;
            High = high;
            Low = low;
            Volume = volume;
            AdjustedClose = adjustedClose;
        }
    }
}
