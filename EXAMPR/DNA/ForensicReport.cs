using System;
using System.Collections.Generic;

namespace DNA;

public class ForensicReport
{
    private Dictionary<string, DateTime> reportMap = new Dictionary<string, DateTime>();

    public Dictionary<string, DateTime> ReportMap
    {
        get { return reportMap; }
        set { reportMap = value; }
    }

    public void addReportDetails(String reportingOfficerName, DateTime reportFiledDate)
    {
        if (!reportMap.ContainsKey(reportingOfficerName))
        {
            reportMap.Add(reportingOfficerName, reportFiledDate);
        }
    }

    public List<String> getOfficersWhoFiledReportsOnDate(DateTime reportFiledDate)
    {
        List<string> officers = new List<string>();

        foreach (var item in reportMap)
        {
            if(item.Value.Date == reportFiledDate.Date)  //.Date ignores timpe part and compares only date
            {
                officers.Add(item.Key); //Adds officer name to list
            }
        }
        return officers;
    }
}