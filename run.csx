//Troubleshoot ARM Deployment
HttpIncomingRequests
|where TIMESTAMP >= datetime(2020-02-11 10:05:00) and TIMESTAMP <= datetime(2020-02-11 10:20:00) 
| where subscriptionId == '069b4cb6-3687-4d61-ba0e-0fab28b3d078' and TaskName contains 'ClientFailure'
    | order by TIMESTAMP asc 

EventServiceEntries 
| where TIMESTAMP >= ago(2d)
| where subscriptionId == '069b4cb6-3687-4d61-ba0e-0fab28b3d078' 
| order by TIMESTAMP asc 


HttpOutgoingRequests
| where PreciseTimeStamp >= ago(7d)
| where subscriptionId == "511587c5-26b7-4c8a-b78a-656db87c4abb"
| where targetUri contains "pod-dev-uksouth-renewals-creator" //and TaskName contains "Failure" and httpStatusCode >= 500
|limit 100

//Troubleshoot Frontend 
AntaresIISLogFrontEndTable 
| where TIMESTAMP >= ago(1d)
|where  S_sitename contains "p-inventory-stock-lookup-v1-qa" and Sc_status >= 400
|order by TIMESTAMP asc 


//Troubleshoot GeoMaster
AntaresAdminGeoEvents
| where TIMESTAMP >= ago(5h)
| where SiteName == 'll1-pr-eune-web-ranks' and Level == 2

//Troubleshoot Controller
AntaresAdminControllerEvents
| where TIMESTAMP >= datetime(2020-01-28 00:00:00) and TIMESTAMP <= datetime(2020-01-28 23:59:00) 
| where SubscriptionId == '172c2b0c-3d01-4f36-90d2-959e35ab630d' and Level == 2
| limit 100
 

ShoeboxEntries 
| where TIMESTAMP >= datetime(2020-01-28 00:00:00) and TIMESTAMP <= datetime(2020-01-28 23:59:00)
| where resourceId contains "devicepilot-eneco-connection" 
| limit 100


//Troubleshoot Worker
AntaresRuntimeWorkerEvents
        |where TIMESTAMP >= datetime(2020-01-30 23:21:34) and TIMESTAMP <= datetime(2020-01-30 23:22:59) 
        | where SiteName contains 'devicepilot-eneco-connection'
        | order by TIMESTAMP asc 
        | where LogStatement contains 'env'
        | project TIMESTAMP, LogStatement


AntaresIISLogWorkerTable
| where TIMESTAMP >= datetime(2020-02-05 08:00:00) and TIMESTAMP <= datetime(2020-02-05 10:00:00) 
| where S_sitename contains "ll1-pr-eune-web-ranks" 
| order by TIMESTAMP asc 
|limit 100 

AntaresWebWorkerEventLogs
| where TIMESTAMP >= datetime(2020-02-05 08:00:00) and TIMESTAMP <= datetime(2020-02-05 10:00:00) 
| where SiteName contains "ll1-pr-eune-web-ranks" 
| order by TIMESTAMP asc 
|limit 100



AntaresWebWorkerFREBLogs
|where TIMESTAMP >= datetime(2020-01-25 00:00:00) and TIMESTAMP <= datetime(2020-01-27 23:59:00) and Level == 2 
|limit 100


//Troubleshoot Publisher
Kudu
|where TIMESTAMP >= datetime(2020-01-01 00:00:00) and TIMESTAMP <= datetime(2020-01-17 23:59:00) 
|where siteName contains 'Collaborationapp-Api' and Level == 2 //and statusCode >= 400
|limit 100

AntaresPublisherEvents
| where TIMESTAMP >= datetime(2020-01-20 00:00:00) and TIMESTAMP <= datetime(2020-01-20 23:59:00) 
| where SubscriptionId == '511587c5-26b7-4c8a-b78a-656db87c4abb' and Level == 2 
|limit 100

AntaresFtpLogs
| where TIMESTAMP >= datetime(2020-01-20 00:00:00) and TIMESTAMP <= datetime(2020-01-20 23:59:00) 
|where * contains 'content-universe-dev' and StatusCode  >= 400 //and Level == 2 //and statusCode >= 400
//|limit 500

MSDeploy
|where SiteName contains 'content-universe-dev'
|where TIMESTAMP >= datetime(2020-01-30 12:00:00) and TIMESTAMP <= datetime(2020-01-30 23:59:00) 
|limit 100

//Auth
AntaresEasyAuthEvents
|where TIMESTAMP >= datetime(2020-01-21 00:05:00) and TIMESTAMP <= datetime(2020-01-21 23:59:00) 
|where SiteName ==   'produksappsapp' 

//Functionlogs
FunctionsLogs 
|where TIMESTAMP >= datetime(2020-02-07 00:00:00) and TIMESTAMP <= datetime(2020-02-07 23:59:00) 
| where SubscriptionId == '92737b87-f428-493f-a978-ce213582f5a0' and Level < 4
| project TIMESTAMP, Summary, Details


//checks all activity of the cx
AntaresAdminSubscriptionAuditEvents 
| where TIMESTAMP >= datetime(2020-01-28 00:00:00) and TIMESTAMP <= datetime(2020-01-28 23:59:00) 
| where SiteName == 'devicepilot-eneco-connection' 
| limit 100



//search all tables
search * 
| where TIMESTAMP >= datetime(2020-01-28 00:00:00) and TIMESTAMP <= datetime(2020-01-28 23:59:00) 


AntaresAdminSubscriptionAuditEvents 
| where TIMESTAMP >= ago(4d)
| where SiteName contains "devp01-cd" 
| order by TIMESTAMP asc 
|limit 100



ScaleControllerEvents
          
		  
AntaresRuntimeDataServiceEvents
    